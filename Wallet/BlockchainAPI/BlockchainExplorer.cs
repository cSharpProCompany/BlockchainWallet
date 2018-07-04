﻿using Nethereum.Hex.HexConvertors;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wallet.BlockchainAPI.Model;
using Wallet.Models;
using Wallet.ViewModels;

namespace Wallet.BlockchainAPI
{
    public class BlockchainExplorer: IBlockchainExplorer
    {
        private static Web3 web3 = new Web3();

        private static string abi =
            "[{\"constant\":false,\"inputs\":[{\"name\":\"spender\",\"type\":\"address\"},{\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"approve\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":true,\"inputs\":[],\"name\":\"totalSupply\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"from\",\"type\":\"address\"},{\"name\":\"to\",\"type\":\"address\"},{\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"transferFrom\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"who\",\"type\":\"address\"}],\"name\":\"balanceOf\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"to\",\"type\":\"address\"},{\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"transfer\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"name\":\"spender\",\"type\":\"address\"},{\"name\":\"value\",\"type\":\"uint256\"},{\"name\":\"extraData\",\"type\":\"bytes\"}],\"name\":\"approveAndCall\",\"outputs\":[{\"name\":\"\",\"type\":\"bool\"}],\"payable\":false,\"type\":\"function\"},{\"constant\":true,\"inputs\":[{\"name\":\"owner\",\"type\":\"address\"},{\"name\":\"spender\",\"type\":\"address\"}],\"name\":\"allowance\",\"outputs\":[{\"name\":\"\",\"type\":\"uint256\"}],\"payable\":false,\"type\":\"function\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"name\":\"owner\",\"type\":\"address\"},{\"indexed\":true,\"name\":\"spender\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Approval\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"name\":\"from\",\"type\":\"address\"},{\"indexed\":true,\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"name\":\"value\",\"type\":\"uint256\"}],\"name\":\"Transfer\",\"type\":\"event\"}]\r\n";

        private static List<Token> tokenContracts = new List<Token>
        {
            new Token("EOS", "0x86fa049857e0209aa7d9e616f7eb3b3b78ecfdb0", 18),
            new Token("TRX", "0xf230b790e05390fc8295f4d3f60332c93bed42e2", 6),
            new Token("BNB", "0xB8c77482e45F1F44dE1745F52C74426C631bDD52", 18),
            new Token("VEN", "0xd850942ef8811f2a866692a623011bde52a462c1", 18),
            new Token("OMG", "0xd26114cd6EE289AccF82350c8d8487fedB8A0C07", 18),
            new Token("LCT", "0x05c7065d644096a4e4c3fe24af86e36de021074b", 18)
        };


        public static List<Token> tokenContractsJson()
        {
            string ethTokens;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BlockchainProject.ethTokens.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    ethTokens = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<List<Token>>(ethTokens);
        }


        public List<CustomTransaction> GetTokenTransfersForAcc(string account, int searchInLastBlocksCount)
        {
            var result = new List<CustomTransaction>();
            var numb = web3.Eth.Blocks.GetBlockNumber.SendRequestAsync().Result;
            Console.WriteLine($"Last block is {numb.Value}");
            for (var i = numb.Value - searchInLastBlocksCount; i <= numb.Value; i++)
            {
                var block = web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(i))
                    .Result;
                if (block != null && block.Transactions != null)
                {
                    block.Transactions.ToList().ForEach(x =>
                    {
                        if (x.Input.StartsWith("0xa9059cbb") && x.Input.Length < 140)
                        {
                            //Model.TransactionInput tInfo = decodeInput(x.Input, string.Empty);
                            //if (string.Equals(tInfo.To, account, StringComparison.CurrentCultureIgnoreCase))
                            //{
                            //    result.Add(new CustomTransaction()
                            //    {
                            //        TransactionHash = x.TransactionHash,
                            //        From = x.From,
                            //        To = x.To,
                            //        Date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(
                            //                   (long) (block.Timestamp.Value)),
                            //        TransferInfo = tInfo
                            //    });
                            //}
                        }
                    });
                }
            }

            return result;
        }

        public async Task<HexBigInteger> GetLastAvailableBlockNumber()
        {
            return await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
        }

        public async Task<List<CustomTransaction>> GetTransactions(string account, int blockNumber)
        {
            var result = new List<CustomTransaction>();
            try
            {
                var block = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(blockNumber));
                if (block != null && block.Transactions != null)
                {
                    block.Transactions.ToList().ForEach(x =>
                    {
                        bool isSender = string.Equals(x.From, account, StringComparison.CurrentCultureIgnoreCase);
                        if (string.Equals(x.To, account, StringComparison.CurrentCultureIgnoreCase) ||
                            isSender)
                        {
                            CustomTransaction t = new CustomTransaction()
                            {
                                Input = x.Input,
                                IsSuccess = false,
                                TransactionHash = x.TransactionHash,
                                From = x.From,
                                To = x.To,
                                What = "ETH",
                                Value = x.Value,
                                Date = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(
                                           (long)(block.Timestamp.Value)),
                                ContractAddress = isSender ? x.To : x.From
                            };
                            result.Add(t);
                        }
                    });
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        /// <summary>
        /// get current balance eth
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Task<HexBigInteger> BalanceETH(string account)
        {
            return web3.Eth.GetBalance.SendRequestAsync(account);
        }

        /// <summary>
        /// get token erc20
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// 
        public async Task<ERC20TokenViewModel> BalanceToken(ERC20Token token, string account)
        {
            try
            {
                var cont = web3.Eth.GetContract(abi, token.Address);
                var eth = cont.GetFunction("balanceOf");
                var balance = await eth.CallAsync<BigInteger>(account);
                return new ERC20TokenViewModel()
                {
                    Address = token.Address,
                    Balance = Web3.Convert.FromWei(balance, token.DecimalPlaces),
                    DecimalPlaces = token.DecimalPlaces,
                    Symbol = token.Symbol
                };
            }
            catch (Exception e)
            {
                return new ERC20TokenViewModel()
                {
                    Address = token.Address,
                    Balance = 0,
                    DecimalPlaces = token.DecimalPlaces,
                    Symbol = token.Symbol
                };
            }

        }
    }
}
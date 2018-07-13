import { Component, OnInit } from '@angular/core';
import { BlockchainService } from '../../shared/services/blockchain.service';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';


@Component({
  selector: 'app-wallet-page',
  templateUrl: './wallet-page.component.html',
  styleUrls: ['./wallet-page.component.css']
})
export class WalletPageComponent implements OnInit{

  constructor(private BCservice: BlockchainService, private router: Router, private activatedRoute: ActivatedRoute,) { }

  ngOnInit() {
    let address = this.activatedRoute.snapshot.paramMap.get('searchString');
    this.BCservice.checkAddress(address).subscribe(res => {
      if (res) {
        this.router.navigate(['/search/contract',address]);
      } else {
        this.router.navigate(['/search/account',address]);
      }
    });
  }

}

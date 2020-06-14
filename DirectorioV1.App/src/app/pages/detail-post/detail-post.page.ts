import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-detail-post',
  templateUrl: './detail-post.page.html',
  styleUrls: ['./detail-post.page.scss'],
})
export class DetailPostPage implements OnInit {
  customer:any={}
  constructor(
    private router: Router
  ) { 
    this.customer = router.getCurrentNavigation().extras.state['customer'];
  }

  ngOnInit() {
  }

  detailPostInfo(item,index){
    console.log({detailPostInfo:'DetailPostInfo',item:item,index:index})
    this.router.navigate(['detail-post-info'],{
      state:{customer:this.customer,address:item}
    })
  }
}

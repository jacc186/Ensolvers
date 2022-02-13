import { NgIf } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  constructor(private service:SharedService) {
    this.data="";
    this.state = false;
   }

  @Input() item:any;
  data:string;
  state:boolean;

  ngOnInit(): void {
    this.data = this.item.data;
    this.state = this.item.state;
  }

  editItem()
  {
    {
      var val =
      {
        data: this.data,
        state: this.state
      };
      this.service.UpdateTask(this.item.itemId,val).subscribe(res=>
        {
          alert("Operation done");
        });
    }
  }
}

import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private service:SharedService) {
    this.data = "";
    this.ModalTitle="";
   }
 @Input() data:any;
  TaskList:any=[];
  ModalTitle:string;
  ActivateEditItem:boolean = false
  item:any;


  ngOnInit(): void {
    this.refreshTaskList();
  }

  refreshTaskList()
  {
    this.TaskList=[];
    this.service.getTaskList().subscribe(data=>{
      this.TaskList = data;
    });
  }
  addClick()
  {
    var val = {data: this.data};
    this.service.addTask(val).subscribe(res=>
      {
        alert(res.toString());
      });
      this.ngOnInit();
  }

  editClick(task: any)
  {
    this.item=task;
    this.ModalTitle="Edit Task";
    this.ActivateEditItem = true;
  }
  closeClick()
  {
    this.ActivateEditItem = false;
    this.refreshTaskList();
  }
  
  deleteClick()
  {

  }

}

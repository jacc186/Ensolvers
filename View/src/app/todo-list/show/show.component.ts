import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {

  constructor(private service:SharedService) { }

  TaskList:any=[];

  ngOnInit(): void {
    this.refreshTaskList();
  }

  refreshTaskList()
  {
    this.service.getTaskList().subscribe(data=>{
      this.TaskList = data;
    });
  }

  addClick()
  {
    
  }

}

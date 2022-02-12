import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44328/api/Items";

  constructor(private http: HttpClient) { }

  getTaskList():Observable<any[]>
  {
    return this.http.get<any[]>(this.APIUrl);
  }
  addTask(val:any)
  {
    return this.http.post(this.APIUrl, val);
  }
  UpdateTask(id:any, val:any)
  {
    return this.http.put(this.APIUrl + "/" + id, val);
  }
  DeleteTask(val:any)
  {
    return this.http.delete(this.APIUrl + '/'+ val);
  }
}

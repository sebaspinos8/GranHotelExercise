import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';
import { GuestResponse } from 'src/models/guestResponse.model';



@Injectable({
  providedIn: 'root'
})
export class GuestService {

  API_URL=environment.apiURL;

  constructor(private http:HttpClient) { }


  getAllGuests(){
    return this.http.get<GuestResponse[]>(this.API_URL+"/GetGuests");
  }

}
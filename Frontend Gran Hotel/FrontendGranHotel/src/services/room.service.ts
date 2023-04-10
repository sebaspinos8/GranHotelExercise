import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';
import { RoomResponse } from 'src/models/roomResponse.interface';



@Injectable({
  providedIn: 'root'
})
export class RoomService {

  API_URL=environment.apiURL;

  constructor(private http:HttpClient) { }

  getAvailabilityRooms(){
    return this.http.get<RoomResponse[]>(this.API_URL+"/GetAllRoomsAvailabilityByHotel?hotelId=1");
  }

  getNotAvailabilityRooms(){
    return this.http.get<RoomResponse[]>(this.API_URL+"/GetAllRoomsNotAvailabilityByHotel?hotelId=1");
  }

  getAllRooms(){
    return this.http.get<RoomResponse[]>(this.API_URL+"/GetAllRooms?hotelId=1");
  }

}
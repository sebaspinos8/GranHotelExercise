import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CheckOutRequest } from 'src/models/checkOutRequest.interface';
import { GuestResponse } from 'src/models/guestResponse.model';
import { reservationRequest } from 'src/models/reservationRequest.interface';
import { ReservationResponse } from 'src/models/reservationResponse.interface';
import { RoomResponse } from 'src/models/roomResponse.interface';
import { GuestService } from 'src/services/guest.service';
import { ReservationService } from 'src/services/reservation.service';
import { RoomService } from 'src/services/room.service';
import swal from'sweetalert2';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 
  title = 'Gran Hotel';
  closeResult: string = "";
  roomsAv: RoomResponse[] = [];
  roomsNAv: RoomResponse[] = [];
  rooms: RoomResponse[]=[];
  guestsAv: GuestResponse[] = [];
  chkRequest:CheckOutRequest = {reservationId:-1};
  reservations : ReservationResponse[]=[];
  room: string="";
  reserv:reservationRequest={guestIdent: "",guestName:"",roomId:-1,reservationInDate: new Date(),reservationoutDate:new Date()};
  

  constructor(private modalService: NgbModal,private router: ActivatedRoute, private guestService:GuestService, private reservationService: ReservationService, private roomService:RoomService){}

 
  


ngOnInit(): void {
  
  this.roomService.getAvailabilityRooms().subscribe(data=>{
    this.roomsAv = data;
  });

  this.roomService.getNotAvailabilityRooms().subscribe(data=>{
    this.roomsNAv = data;
  });

  this.roomService.getAllRooms().subscribe(data=>{
    this.rooms = data;
  });

  this.guestService.getAllGuests().subscribe(data=>{
    this.guestsAv = data;
  });

  this.reservationService.getReservationsOut().subscribe(data=>{
    this.reservations = data;
  });

}

ngAfterViewInit() {}


open(content: any) {
  
  this.roomService.getAvailabilityRooms().subscribe(data=>{
    this.roomsAv = data;
    this.reservationService.getReservationsOut().subscribe(data=>{
      this.reservations = data;
      this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title',size: 'lg', windowClass: 'modal-xl'}).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult = `Dismissed`;
      });
    });
  });
  
}
changeSelect(){
  this.roomService.getAvailabilityRooms().subscribe(data=>{
    this.roomsAv = data;
  });
}

saveCheckIn(){
  if(this.validate()){
    this.reservationService.checkIn(this.reserv).subscribe(
      (data:any)=>{
        swal.fire(data.message.toString(),"", 'success');
    }, 
      error=>swal.fire(error.error.toString(),"", 'error')
      );
  }else{
    swal.fire("Fill All the Fields to Continue","", 'warning');
  }
}

saveCheckOut(reservId:number){
  this.chkRequest.reservationId = reservId;
    this.reservationService.checkOut(this.chkRequest).subscribe(
      (data:any)=>{
        this.reservationService.getReservationsOut().subscribe(data=>{
          this.reservations = data;
        });
        swal.fire(data.message.toString(),"", 'success');
      }, 
      error=>swal.fire(error.error.toString(),"", 'error')
      );
}

validate(){

  if(this.reserv.guestIdent ==""){
    return false;
  }else{
    if(this.reserv.guestName == ""){
      return false
    }else{
      if(this.reserv.roomId == -1){
        return false;
      }else{
         return true
      }
    }
  }
}




}

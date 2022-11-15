import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/models/app-user';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
})
export class MemberDetailComponent implements OnInit {
  // member: Member = {
  //   username: 'ebutteris0',
  //   email: 'edrei0@noaa.gov',
  //   age: 28,
  //   knownAs: 'Esme',
  //   gender: 'Female',
  //   city: 'Nyköping',
  //   introduction:
  //     'sit amet diam in magna bibendum imperdiet nullam orci pede venenatis non sodales sed tincidunt eu felis fusce',
  //   avatar:
  //     'https://robohash.org/sitexercitationemdolorum.png?size=250x250&set=set1',
  // };
  @Input() member: Member | null = null;
  constructor() {}
 
  ngOnInit(): void {}
}

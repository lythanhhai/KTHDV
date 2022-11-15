import { Component, OnInit } from '@angular/core';
import { Member } from 'src/models/app-user';
import { MemberService } from '../_services/member.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css'],
})
export class MembersComponent implements OnInit {
  members: Member[] = [];
  constructor(private memberService: MemberService) {}

  ngOnInit(): void {
    this.memberService.getMembers().subscribe((members) => {
      // console.log(members);
      this.members = members;
    });
  }
}

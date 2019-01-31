import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_sevices/user.service';
import { AlertifyService } from 'src/app/_sevices/alertify.service';
import { Route, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/_models/user';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
  selector: 'app-members-details',
  templateUrl: './members-details.component.html',
  styleUrls: ['./members-details.component.css']
})
export class MembersDetailsComponent implements OnInit {
user: User;
GallaryOptions: NgxGalleryOptions[];
GallaryImages: NgxGalleryImage[];
  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
this.user = data['user'];

    } );
this.GallaryOptions = [
  {
    width: '500px',
    height: '500px',
    imagePercent: 100,
    thumbnailsColumns: 4,
    imageAnimation: NgxGalleryAnimation.Slide,
    preview: false

  }
];
this.GallaryImages = this.getimage();


}
getimage() {
  const imageUrl = [];
  for ( let i = 0; i < this.user.photos.length; i++) {
imageUrl.push({
small: this.user.photos[i].url,
medium: this.user.photos[i].url,
big: this.user.photos[i].url,
descriptions: this.user.photos[i].description
});
  }
  return imageUrl;
}
}

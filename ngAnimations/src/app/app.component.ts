import { transition, trigger, useAnimation } from '@angular/animations';
import { Component } from '@angular/core';
import { bounce, shake, shakeX, tada } from 'ng-animate';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone: true,
    animations: [
    trigger('shake', [transition('* => *', useAnimation(shake, {
      // Set the duration to 3 seconds and delay to 1 second
      params: { timing: 2, delay: 0 }
    }))]),
    trigger('bounce', [transition('* => *', useAnimation(bounce,{
       params: { timing: 4, delay: 2 }
    }))]),
    trigger('tada', [transition('* => *', useAnimation(tada,{
       params: { timing: 3, delay: 5 }
    }))])
],
})
export class AppComponent {
  title = 'ngAnimations';
    mavariable=0;
 // shake= false;
bounce=false;
  constructor() {
  }

 
  
}

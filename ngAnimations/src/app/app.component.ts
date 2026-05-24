import { transition, trigger, useAnimation } from '@angular/animations';
import { Component } from '@angular/core';
import { bounce, shake, shakeX, tada } from 'ng-animate';
import { lastValueFrom, timer } from 'rxjs';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone: true,
    animations: [
    trigger('shake', [
    transition(':increment', useAnimation(shake, { params: { timing: 2 } }))
  ]),
  trigger('bounce', [
    transition(':increment', useAnimation(bounce, { params: { timing: 4 } }))
  ]),
  trigger('tada', [
    transition(':increment', useAnimation(tada, { params: { timing: 3 } }))
  ])
],
})
export class AppComponent {
  title = 'ngAnimations';
  ng_shake = 0;
ng_bounce = 0;
ng_tada = 0;

css_rotate = false;




  constructor() {
  }

 
  waitFor(seconds: number) {
  return lastValueFrom(timer(seconds * 1000));
}

async playOnce() {

  // 1) Shake rouge 2 sec
  this.ng_shake++;
  await this.waitFor(2);

  // 2) Bounce vert 4 sec
  this.ng_bounce++;

  // 3) Tada bleu → commence 1 sec avant la fin du bounce
  await this.waitFor(3); // 4 sec - 1 sec
  this.ng_tada++;

  // Attendre la fin du tada (3 sec)
  await this.waitFor(3);
}

loop = false;

async playLoop() {
  this.loop = true;

  while (this.loop) {

    this.ng_shake++;
    await this.waitFor(2);

    this.ng_bounce++;
    await this.waitFor(3);

    this.ng_tada++;
    await this.waitFor(3);
  }
}

stopLoop() {
  this.loop = false;
}


playRotate() {
  this.css_rotate = true;

  setTimeout(() => {
    this.css_rotate = false;
  }, 2000); // même durée que ton animation CSS
}


}

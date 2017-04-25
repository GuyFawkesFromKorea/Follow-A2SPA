import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'my-app',
  //template: `<h1>Hello {{name}}</h1>`,
  templateUrl:'/partial/appComponent'
})

//export class AppComponent  { name = 'Angular'; }
export class AppComponent {
    public constructor(private titleService: Title) { }

    angularClientSideData = 'Angular';

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }
}

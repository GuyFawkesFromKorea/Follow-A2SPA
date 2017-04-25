//import { NgModule }      from '@angular/core';
//import { BrowserModule } from '@angular/platform-browser';

//import { AppComponent }  from './app.component';

//@NgModule({
//  imports:      [ BrowserModule ],
//  declarations: [ AppComponent ],
//  bootstrap:    [ AppComponent ]
//})
//export class AppModule { }


import { NgModule, enableProdMode } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { routing, routedComponents } from './app.routing';
import { APP_BASE_HREF, Location } from '@angular/common';
import { AppComponent } from './app.component';

// enableProdMode();

@NgModule({
    imports: [BrowserModule, routing],
    declarations: [AppComponent, routedComponents],
    providers: [Title, { provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent]
})
export class AppModule { }
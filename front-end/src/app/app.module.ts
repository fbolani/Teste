import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { ListarComponent } from 'src/app/pages/lancamento/listar/listar.component';
import { CadastrarComponent } from 'src/app/pages/lancamento/cadastrar/cadastrar.component';
import { EditarComponent } from 'src/app/pages/lancamento/editar/editar.component';
import { ConciliarComponent } from 'src/app/pages/conciliar/conciliar.component';
import { RelatorioMensalComponent } from 'src/app/pages/relatorio-mensal/relatorio-mensal.component';
import {NgxMaskModule} from 'ngx-mask'
import { NgxCurrencyModule } from "ngx-currency";

@NgModule({
  declarations: [
    AppComponent,
    ListarComponent,
    CadastrarComponent,
    EditarComponent,
    ConciliarComponent,
    RelatorioMensalComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    NgxMaskModule.forRoot(),
    NgxCurrencyModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
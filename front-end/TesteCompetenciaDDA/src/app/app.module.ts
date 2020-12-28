import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from 'src/app/app-routing.module';
import { AppComponent } from 'src/app/app.component';
import { ListarComponent } from 'src/app/pages/lancamento/listar/listar.component';
import { CadastrarComponent } from 'src/app/pages/lancamento/cadastrar/cadastrar.component';
import { EditarComponent } from 'src/app/pages/lancamento/editar/editar.component';
import { ConciliarComponent } from 'src/app/pages/conciliar/conciliar.component';
import { RelatorioMensalComponent } from 'src/app/pages/relatorio-mensal/relatorio-mensal.component';

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
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
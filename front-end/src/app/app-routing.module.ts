import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

import { ListarComponent } from 'src/app/pages/lancamento/listar/listar.component';
import { CadastrarComponent } from 'src/app/pages/lancamento/cadastrar/cadastrar.component';
import { EditarComponent } from 'src/app/pages/lancamento/editar/editar.component';
import { ConciliarComponent } from 'src/app/pages/conciliar/conciliar.component';
import { RelatorioMensalComponent } from 'src/app/pages/relatorio-mensal/relatorio-mensal.component';

const routes: Routes = [
  { path: '', redirectTo: 'lancamento', pathMatch: 'full' },
  { path: 'lancamento', component: ListarComponent },
  { path: 'lancamento/:id', component: EditarComponent },
  { path: 'lancamento/cadastrar', component: CadastrarComponent },
  { path: 'conciliar', component: ConciliarComponent },
  { path: 'relatorio-mensal', component: RelatorioMensalComponent },
];

@NgModule({
  imports: [
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
import { Component, OnInit } from '@angular/core';
import { Lancamento } from 'src/app/models/lancamento.model';
import { LancamentoService } from 'src/app/services/lancamento.service';
import { BalancoService } from 'src/app/services/balanco.service';

@Component({
  selector: 'app-conciliar',
  templateUrl: './conciliar.component.html'
})
export class ConciliarComponent implements OnInit {
  lancamentos: Lancamento[] = [];
  constructor(private _lancamentoService: LancamentoService,
    private _balancoService: BalancoService) { }
  data: String = "";

  ngOnInit() {
    var data = new Date();
    var dia = data.getDate();
    var mes = data.getMonth() + 1;
    var ano = data.getFullYear();

    this.data = [ano, mes, dia].join('-');

    this._lancamentoService.getByDate(this.data).subscribe(
      s => this.lancamentos = s
    );
  }

  formatarDataHora(data: Date) {
    if (data)
      return data.toLocaleString().substr(0, 10);
    else
      return "";
  }

  formatarValorParaReal(valor: number) {
    return new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(valor);
  }

  formatarTipo(idTipo: number) {
    if (idTipo == 1) {
      return "Débito";
    } else {
      return "Crédito";
    }
  }

  formatarStatus(status: boolean) {
    if (status) {
      return "Conciliado";
    } else {
      return "Não Conciliado";
    }
  }

  onConciliarClick() {
    this._balancoService.conciliar(this.data)
      .subscribe(() => { },
        (error: any) => {          
          if (error.error == null) {
            alert(error.message);
            return;
          }
          let mensagem = "";
          for (var i = 0; i < error.error.length; i++) {
            if (mensagem != "") {
              mensagem += "\n"
            }
            mensagem += error.error[i];
          }
          alert(mensagem);
        },
        () => { });
  }
}
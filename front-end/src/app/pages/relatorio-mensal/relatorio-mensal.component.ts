import { Component, OnInit } from '@angular/core';
import { Balanco } from 'src/app/models/balanco.model';
import { BalancoService } from 'src/app/services/balanco.service';

@Component({
  selector: 'app-relatorio-mensal',
  templateUrl: './relatorio-mensal.component.html'
})
export class RelatorioMensalComponent implements OnInit {
  balancos: Balanco[] = [];
  constructor(private _balancoService: BalancoService) { }

  ngOnInit() {
    var data = new Date();
    var mes = data.getMonth() + 1;

    this._balancoService.getBalancoMes(mes).subscribe(
      s => { this.balancos = s },
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
      () => { }
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

  somarValorCredito() {
    var sum = this.balancos.reduce((a, b) => a + b.valorCredito, 0);
    return this.formatarValorParaReal(sum);
  }

  somarValorDebito() {
    var sum = this.balancos.reduce((a, b) => a + b.valorDebito, 0);
    return this.formatarValorParaReal(sum);
  }

  somarValorTotal() {
    var sum = this.balancos.reduce((a, b) => a + b.valorTotal, 0);
    return this.formatarValorParaReal(sum);
  }
}
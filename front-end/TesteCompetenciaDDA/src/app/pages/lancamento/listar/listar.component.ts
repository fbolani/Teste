import { Component, OnInit } from '@angular/core';
import { Lancamento } from 'src/app/models/lancamento.model';
import { LancamentoService } from 'src/app/services/lancamento.service';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styles: ['./listar.component.css']
})
export class ListarComponent implements OnInit {
  lancamentos: Lancamento[];
  constructor(private _lancamentoService: LancamentoService) { }

  ngOnInit() {
    this.onLoad();
  }

  onLoad() {
    this._lancamentoService.get().subscribe(
      s => { this.lancamentos = s },
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

  formatarDataHora(data: string) {
    if (data)
      return new Date(data).toLocaleString().substr(0, 10);
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

  onRemoveClick(id) {
    if (confirm("Confirma a exclusão do item ID: " + id + " ?")) {
      this._lancamentoService.delete(id).subscribe(
        () => { alert("Exclusão realizada com sucesso"); },
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
        () => { this.onLoad(); });
    }
  }

}
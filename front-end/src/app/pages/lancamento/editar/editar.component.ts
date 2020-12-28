import { Component, OnInit } from '@angular/core';
import { Lancamento } from 'src/app/models/lancamento.model';
import { LancamentoService } from 'src/app/services/lancamento.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html'
})
export class EditarComponent implements OnInit {
  lancamento: Lancamento = {};
  id: number = 0;
  tipo: number = 1;
  valor: string = "";
  data: string = "";

  constructor(private _lancamentoService: LancamentoService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    this.id = parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit() {
    this.onLoad();
  }

  onLoad() {
    this._lancamentoService.getById(this.id).subscribe(
      s => { this.lancamento = s },
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
      () => {
        this.data = this.formatarDataHora(this.lancamento.dataHora);
        this.valor = this.formatarValorParaReal(this.lancamento.valor);
        this.tipo = this.lancamento.tipo;
      });
  }

  formatarDataHora(data: Date) {
    if (data)
      return data.toLocaleString().substr(0, 20).replace("T", " ");
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

  onRemoveClick(id: number) {
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

  onEditClick(id: number) {
    this.router.navigate(['/lancamento', id]);
  }

}

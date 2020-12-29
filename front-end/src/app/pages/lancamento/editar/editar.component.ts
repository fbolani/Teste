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
  valor: number = 0;
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
        this.valor = this.lancamento.valor;
        this.tipo = this.lancamento.tipo;
      });
  }

  formatarDataHora(data: string) {
    if (data)
      return new Date(data).toLocaleString().substr(0, 20).replace("T", " ");
    else
      return "";
  }

  formatarDataHoraJS(data: string) {
    data = data
      .replace("/", "")
      .replace("/", "")
      .replace(" ", "")
      .replace(":", "")
      .replace(":", "")
      .replace(".", "");
    console.log(data);
    if (!data || data.length != 14) {
      alert("formato da data é invalido, deve seguir o padrao DD/MM/AAAA HH:MM:SS");
      return null;
    }
    let dia: number = parseInt(data.substring(0, 2));
    let mes: number = parseInt(data.substring(2, 4));
    let ano: number = parseInt(data.substring(4, 8));
    let hora: number = parseInt(data.substring(8, 10));
    let minuto: number = parseInt(data.substring(10, 12));
    let segundo: number = parseInt(data.substring(12, 14));
    return `${ano}-${mes}-${dia} ${hora}:${minuto}:${segundo}`;
  }

  onSalvar() {
    let lancto: Lancamento = {
      dataHora: this.formatarDataHoraJS(this.data),
      id: null,
      status: false,
      valor: this.valor,
      tipo: parseInt(this.tipo.toString())
    }

    if (lancto.dataHora == null) {
      return;
    }

    this._lancamentoService.put(this.id, lancto).subscribe(
      () => {
        this.router.navigate(['lancamento']).then(() => {
          alert('Lançamento atualizado!');
        });
      },
      (error: any) => {
        console.log(error)
        if (error.error == null) {
          if (error.message) {
            alert(error.message);
          }
          else {
            alert(error.title);
          }
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
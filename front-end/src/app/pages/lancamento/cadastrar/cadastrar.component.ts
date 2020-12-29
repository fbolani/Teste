import { Component, OnInit } from '@angular/core';
import { Lancamento } from 'src/app/models/lancamento.model';
import { LancamentoService } from 'src/app/services/lancamento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html'
}) 
export class CadastrarComponent implements OnInit {
  tipo: number = 1;
  valor: number = 0;
  data: string = "";

  constructor(private _lancamentoService: LancamentoService,
    private router: Router) {
  }

  ngOnInit() {
    console.log("cadastrar");
  }

  formatarDataHoraJS(data: string) {
    if (!data || data.length != 14) {
      alert("formato da data é invalido");
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

    this._lancamentoService.post(lancto).subscribe(
      () => {
        this.router.navigate(['lancamento']).then(() => {
          alert('Lançamento cadastrado!');
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
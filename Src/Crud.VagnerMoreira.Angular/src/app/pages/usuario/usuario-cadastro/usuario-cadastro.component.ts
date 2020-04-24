import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ErroModel } from '../../../models/erro.model';
import { OrderService } from 'src/app/services/pages/order.service';
import { usuarioAdicionarResponseModel} from 'src/app/models/usuario.model';


@Component({
  selector: 'app-usuario-cadastro',
  templateUrl: './usuario-cadastro.component.html',
  styleUrls: ['./usuario-cadastro.component.scss']
})
export class usuarioCadastroComponent implements OnInit {

  public usuarios: usuarioAdicionarResponseModel[];
  public usuario: usuarioAdicionarResponseModel;

  constructor(
    private orderService: OrderService,
    private activatedRoute: ActivatedRoute,
    private ts: ToastrService,
    private router: Router
  ) { }

  public id = 0;
  public erros: ErroModel[];
  public formCadastro: FormGroup = new FormGroup({
    id: new FormControl(0),
    order: new FormControl(''),
  });
 

  ngOnInit() {

    if (this.activatedRoute.snapshot.params.id !== undefined && this.activatedRoute.snapshot.params.id != null) {
      this.id = Number(this.activatedRoute.snapshot.params.id);
    }
  }

  
  private validar(): boolean {
    this.erros = new Array<ErroModel>();
    if (this.formCadastro.get('order').value === "") {
      this.erros.push(new ErroModel(400, 'Order é obrigatorio'));
    }
 

    return !this.erros || this.erros.length === 0;
  }

  salvar() {
    if (!this.validar()) {
      return;
    }

    if (this.id === 0) {
      this.adicionar();
    } 
  }

 
  adicionar(): void {
    this.orderService.adicionar(this.formCadastro.value)
      .subscribe((response) => {
        this.usuario = new usuarioAdicionarResponseModel();
         this.usuario.order = response.order;
         if(this.usuarios == null)
         {         
           this.usuarios = new Array<usuarioAdicionarResponseModel>();
         }
         this.erros = null;
        this.usuarios.push(this.usuario);
        this.ts.success('order registered.');
      }, error => {
        this.erros = error.error.erros;
      });
  }

}

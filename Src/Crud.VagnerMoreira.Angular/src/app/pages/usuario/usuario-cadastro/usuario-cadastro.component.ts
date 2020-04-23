import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ErroModel } from '../../../models/erro.model';
import { UsuarioService } from 'src/app/services/pages/usuario.service';
import { MarcaListarResponseModel } from 'src/app/models/marca.model';
import { usuarioAdicionarRequestModel, usuarioObterResponseModel, usuarioAdicionarResponseModel, usuarioEditarResponseModel } from 'src/app/models/usuario.model';
import { ModeloListarResponseModel } from 'src/app/models/modelo.model';
import { VersaoListarResponseModel } from 'src/app/models/versao.model';

@Component({
  selector: 'app-usuario-cadastro',
  templateUrl: './usuario-cadastro.component.html',
  styleUrls: ['./usuario-cadastro.component.scss']
})
export class usuarioCadastroComponent implements OnInit {

  constructor(
    private usuarioService: UsuarioService,
    private activatedRoute: ActivatedRoute,
    private ts: ToastrService,
    private router: Router
  ) { }

  public id = 0;
  public erros: ErroModel[];
  public formCadastro: FormGroup = new FormGroup({
    id: new FormControl(0),
    nome: new FormControl(''),
    dataNascimento: new FormControl(''),
    email: new FormControl(''),
    senha: new FormControl(''),
    sexo: new FormControl(0)    
  });
  public marcas: MarcaListarResponseModel[];
  public modelos: ModeloListarResponseModel[];
  public versoes: VersaoListarResponseModel[];

  ngOnInit() {

//    this.listarMarca();

    if (this.activatedRoute.snapshot.params.id !== undefined && this.activatedRoute.snapshot.params.id != null) {
      this.id = Number(this.activatedRoute.snapshot.params.id);
    }

    if (this.id > 0) {
      this.obter();
    }
  }

  
  private validar(): boolean {
    this.erros = new Array<ErroModel>();
    if (this.formCadastro.get('nome').value === "") {
      this.erros.push(new ErroModel(400, 'Nome é obrigatorio'));
    }

    if (this.formCadastro.get('email').value === "") {
      this.erros.push(new ErroModel(400, 'email é obrigatorio'));
    }

    if (this.formCadastro.get('senha').value === "") {
      this.erros.push(new ErroModel(400, 'Senha é obrigatorio'));
    }

    if (this.formCadastro.get('dataNascimento').value === "") {
      this.erros.push(new ErroModel(400, 'Data Nascimento é obrigatorio'));
    }

    return !this.erros || this.erros.length === 0;
  }

  salvar() {
    if (!this.validar()) {
      return;
    }

    if (this.id === 0) {
      this.adicionar();
    } else {
      this.editar();
    }
  }

  obter(): void {
    this.usuarioService.obter(this.id)
      .subscribe((response: usuarioObterResponseModel) => {
        this.formCadastro.patchValue({
          id: response.id,
          marca: response.marca,
          modelo: response.modelo,
          versao: response.versao,
          observacao: response.observacao,
          ano: response.ano,
          quilometragem: response.quilometragem
        });

        this.changeMarca();
        this.changeModelo();
      }, error => {
        this.ts.error(error);
      });
  }

  adicionar() {
    this.usuarioService.adicionar(this.formCadastro.value)
      .subscribe((response: usuarioAdicionarResponseModel) => {
        this.ts.success('usuario cadastrado com sucesso.');
        this.router.navigate(['/usuario-consulta/']);
      }, error => {
        this.erros = error.error.erros;
      });
  }

  editar() {
    this.usuarioService.editar(this.formCadastro.value)
      .subscribe((response: usuarioEditarResponseModel) => {
        this.ts.success('usuario editado com sucesso!');
        this.router.navigate(['/usuario-consulta/']);
      }, error => {
        this.erros = error.error.erros;
      });
  }

  changeMarca() {
    const marcaId = this.formCadastro.get('marca').value;
    this.formCadastro.patchValue({
      modelo: 0,
      versao: 0
    });
    this.modelos = new Array<ModeloListarResponseModel>();
    this.versoes = new Array<VersaoListarResponseModel>();

  
  }

  changeModelo() {
    const modeloId = this.formCadastro.get('modelo').value;
    this.formCadastro.patchValue({
      versao: 0
    });
    this.versoes = new Array<VersaoListarResponseModel>();

  
  }
}

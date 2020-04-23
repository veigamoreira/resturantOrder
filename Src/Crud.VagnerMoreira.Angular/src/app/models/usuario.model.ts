import { ErroModel } from './erro.model';

export class usuarioAdicionarRequestModel {
  public marca: string;
  public modelo: string;
  public versao: string;
  public Observacao: string;
  public ano: number;
  public quilometragem: number;
}

export class usuarioAdicionarResponseModel {
  public id: number;
  public erros: ErroModel[];
}

export class usuarioEditarRequestModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public Observacao: string;
  public ano: number;
  public quilometragem: number;
}

export class usuarioListarResponseModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public ano: number;
  public quilometragem: number;
}

export class usuarioObterResponseModel {
  public id: number;
  public marca: string;
  public modelo: string;
  public versao: string;
  public ano: number;
  public quilometragem: number;
  public observacao: string;
}

export class usuarioDeletarResponseModel {
  public erros: ErroModel[];
}

export class usuarioEditarResponseModel {
  public erros: ErroModel[];
}

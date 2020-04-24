import { ErroModel } from './erro.model';

export class usuarioAdicionarRequestModel {
  public order: string;
 }

export class usuarioAdicionarResponseModel {
  public id: number;
  public order : string;
  public erros: ErroModel[];
}



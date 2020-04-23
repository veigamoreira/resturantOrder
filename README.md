1) Explique com suas palavras o que é domain driven design e sua importância na estratégia de desenvolvimento de software.
O DDD é um padrão de desenvolvimento onde separa-se muito bem as classes de negócio e classes de infraestrutura. Com esse padrão evita-se duplicidade de codigo, é melhor para dar manutenção, as regras de negocio ficam melhor definidas e ganha-se muito com a construção de testes.
     
2) Explique com suas palavras o que é e como funciona uma arquitetura baseada em microservices. explique ganhos com este modelo e desafios em sua implementação.

Arquitetura de microservices é uma forma de se quebrar um serviço ou módulo muito coplexo em pequenos servicos , desta forma , é mais performatico, tem maior legibilidade no código. Para se testar há mais vantagens. Esses serviços são independentes uns dos outros e podem se comunicar entre si.


3) explique qual a diferença entre comunicação sincrona e assincrona e qual o melhor cenário para utilizar uma ou outra.


COMUNICAÇÃO DE DADOS ASSÍNCRONA

Na Transmissão Assíncrona, um bit especial é inserido no início e no fim da transmissão de um caractere e assim permite que o receptor entenda o que foi realmente transmitido. Imagine uma sequência de dados que precisam ser transmitidos. Cada bloco de dados possui uma flag (espécie de controle) que informa onde começa e onde acaba esse bloco, além da posição na sequência de dados transmitida.

Com isso, os dados podem ser transmitidos em qualquer ordem e cabe ao receptor interpretar essas informações e colocá-los no lugar correto. Porém, a desvantagem é a má utilização do canal, pois os caracteres são transmitidos irregularmente, além de um alto overhead (os bits de controle que são adicionados no início e no fim do caractere), o que ocasiona uma baixa eficiência na transmissão dos dados.

COMUNICAÇÃO DE DADOS SÍNCRONA

Na comunicação de dados síncrona, o dispositivo emissor e o dispositivo receptor devem estar num estado de sincronia antes da comunicação iniciar e permanecer em sincronia durante a transmissão. Imagine a mesma sequência de dados que precisa ser transmitida de maneira síncrona. Cada bloco de informação é transmitido e recebido num instante de tempo bem definido e conhecido pelo transmissor e receptor, ou seja, estes têm que estar sincronizados. Quando um bloco é enviado, o receptor é bloqueado e só pode enviar outro bloco quando o primeiro for recebido pelo receptor.

Prós e contras

Transferências assíncronas são geralmente mais rápidas do que transferências síncronas. Isso se deve ao fato de que não existe um tempo para coordenar a transmissão. No entanto, devido a isso, mais erros tendem a ocorrer nas transferências assíncronas. Se muitos erros ocorrem, isso pode invalidar o tempo salvo com o tempo inicial de configuração dos parâmetros porque o receptor terá que tomar medidas para corrigir os erros.

Usos

Transferências assíncronas funcionam bem em situações onde a troca ocorre sobre um meio físico confiável, como a fibra ótica ou cabo coaxial, por exemplo. Isso ajuda a minimizar os erros de transmissão, portanto o tempo salvo com a configuração dos parâmetros resulta em uma transferência mais rápida do ponto de vista do usuário final. As transferências síncronas funcionam bem para meios menos confiáveis, como fios elétricos ou sinais de rádio. Aqui, vale a pena levar mais tempo para coordenar os detalhes da transferência, pois isso compensa pelos erros cometidos no meio físico.

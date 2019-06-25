# blockchain-plataform
Blockchain-Plataform

A aplicação esta dividida em 3 menus
1) Block Explorer: Contem todos os blocos que foram minerado até o momento.
 - Essa tela lista o indíce do bloco e o número de transações mineradas. Haverá ao menos uma transação para cada bloco que é a Coinbase
 - Ela possui uma pesquisa que pode ser feita pelo indice do bloco ou o id da transação
 - Há também 3 botões, a saber: 
   - "Return Blockchain Json" - Retorna a Chain
   - "Return Utxo Json"       - Retorna todos os outputs que não foram gastos
   - "Transaction Pool Json"  - Retrona todas as transações que estão para ser mineradas
2) Miner: Lista todas as transações que precisam ser mineradas.
 - Possui listagem do hash da transação e a quantidade de inputs e outputs para essa transação
 - Possui o botão de mineração para inclui-las na Chain
3) Wallet: Tela de gerenciamento das wallets.
 - Sua listagem diz respeito às carteiras e a soma de todos o utxo.
 - Pode-se criar um nova wallet no botão "New Wallet"
 - Pode-se enviar valores entre carteiras no botão "Send"
 
 O Core do Blockchain esta definido no projeto Blockchain.Core dentro da pasta Models
 Dentro da classe Blockchain existe uma variavel de nome "Difficulty" que indica a quantidade de zeros que o hash precisa possuir.
 O processo de SH256 é feito dentro do projeto Blockchain.Core dentro da pasta Utility na classe Criptografy
 O Nonce encontra-se na classe Block.
 O fee sempre será a diferença entre inputs e outputs
 


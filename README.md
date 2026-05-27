BlackOut

João Amaral - Criação do menu, spawn random de células ligadas, documentação do relatório

Francisco Rosa - Comentário do código e adição do Spectre.Console em algumas linhas de código

Francisco Caldeira - Criação do modelo MVC, inicialização do repositório git, e correção de bugs

Repositório github: https://github.com/YellowPaintGames/Blackout---Projeto-Final-LP
---
Bibliotecas usadas: Spectre.Console
---
BlackoutBoard: A classe responsável pela informação dentro do Board, e a sua lógica

Controller: A classe responsável por começar o jogo e chamar a proxima jogada

IView: A classe responsável pela cena de mostrar coisas (no nosso caso usando Specter.Console) para mostrar a área de jogo

Pip: A classe responsável pelas celulas, que tem 2 estados, ligado ou desligado

SpectreView: A classe responsável pelo que vai ser utilizado para mostrar o tabuleiro

Program: O início do programa

---
```mermaid
classDiagram
    SpectreView <|-- IView
    SpectreView <--> Controller
    BlackoutBoard <--> Controller
    BlackoutBoard <-- Pip
    class BlackoutBoard{
        -C: Controller
        -size: int
        +Board: Pip[,]
        
        +BlackoutBoard(size: int, controller: Controller)
        +ToggleBoard()
    }

    class Controller{
        -View: IView
        -Board: BlackoutBoard
        
        +StartController(v: IView)
        +StartGame()
        +NextTurn()
    }

    class IView{        
        +ShowBoard(B: BlackoutBoard)
        +SetControllerRef(C: Controller)
        +PromptUser(B: BlackoutBoard): (int,int)
        +PromptMenuChoice()
        +PromptStart(): int
    }

    class Pip{        
        +On: bool

        +Toggle()
        +ToString(): string
    }

    class SpectreView{        
        -Controller: Controller

        +ShowBoard(B: BlackoutBoard)
        +PromptUser(B: BlackoutBoard): (int,int)
        +PromptMenuChoice()
        +PromptStart(): int
        +SetControllerRef(C: Controller)
    }

    class Program{
        -Main(args: string[])
    }
```
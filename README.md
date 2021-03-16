# PixNet
PixNet - Biblioteca de classes .NET Standard para geração do Payload de transações estáticas Pix em texto (código copia e cola) ou QRCode. 

## Instalação
Para instalar você pode utilizar o site do gerenciador de pacotes .NET Nuget clicando [AQUI](https://www.nuget.org/packages/PixNet).

OU

- .NET CLI
```
dotnet add package PixNet
```
- Package Manager
```
Install-Package PixNet
```

## Utilização
Após instalação você deve usar  adiretiva do pacote
```cs
using PixNet;
```

Com a biblioteca presente no código você deve utilizar o gerador de payload juntamente com os dados de entrada que devem ser um json conforme o exemplo abaixo
```cs
string json = @"{
                Name: 'Lucas Pompeu Neves',
                Key: 'lucaspompeuneves@gmail.com',
                City: 'Ananindeua',
                Amount: 5.50, 
                Description: 'Invoice #8', 
                TransactionID: 'EGUATECH', 
            }";
            
Pix.Payload(json);

// Saída: 00020126620014br.gov.bcb.pix0126lucaspompeuneves@gmail.com0210Invoice #852040000530398654045.505802BR5918Lucas Pompeu Neves6010Ananindeua62120508EGUATECH63041E04

```

Ao final você terá um código semelhante ao exemplo abaixo
```cs
using System;
using PixNet;

namespace TestePixNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
                Name: 'Lucas Pompeu Neves',
                Key: 'lucaspompeuneves@gmail.com',
                City: 'Ananindeua',
                Amount: 5.50, 
                Description: 'Invoice #8', 
                TransactionID: 'EGUATECH', 
            }";

            Console.WriteLine(Pix.Payload(json));
        }
    }
}

```

Por fim você pode usar esse código payload para a função de copiar e colar ou gerar um QRCode estático a partir dele *(Em breve este pacote terá esta funcionalidade)*.

string marca = "";
string modelo = "";
string preço = "";
string corpo = "";
string captadores = "";
string ponte = "";
string corAcabamento = "";
string quantidade = "";

string? readResult;
string menuSelection = "";

int maxGuitarras = 20;

string[,] guitarras = new string[maxGuitarras, 8];

for (int i = 0; i < maxGuitarras; i++)
{
    guitarras[i, 0] = marca;
    guitarras[i, 1] = modelo;
    guitarras[i, 2] = preço;
    guitarras[i, 3] = corpo;
    guitarras[i, 4] = captadores;
    guitarras[i, 5] = ponte;
    guitarras[i, 6] = corAcabamento;
    guitarras[i, 7] = quantidade;
}

do
{
Console.WriteLine("Controle de Estoque - Instrumentos Musicais - Guitarras\n");
Console.WriteLine("[1] - Novo\n[2] - Listar Produtos\n[3] - Remover Produtos\n[4] - Entrada de Estoqu\n[5] - Saída de Estoque\n[0] - Sair");

readResult = Console.ReadLine();

if (readResult != null)
{
    menuSelection = readResult;
}

switch (menuSelection)
{
    case "1":
        NovoProduto();
        break;
    case "2":
        ListarProdutos();
        break;
    case "3":
        RemoverProdutos();
        break;
    case "4":
        EntradaOuSaidaDeEstoque("+");
        break;
    case "5":
        EntradaOuSaidaDeEstoque("-");
        break;
    case "0":
        break;
}

Console.WriteLine("Pressione enter para continuar...");
Console.ReadLine();

} while (menuSelection != "0");

void RemoverProdutos()
{   
    int i;
    bool validEntry = false;

    do
    {
        Console.WriteLine("Informe a posição da guitarra a ser removida: ");
        if (int.TryParse(Console.ReadLine(), out i))
        {
            validEntry = true;
            for (int j = 0; j < 8; j++)
            {
                guitarras[i - 1, j] = "";
            }
        }
        else
            validEntry = false;
    } while (!validEntry && (i > maxGuitarras || i <= 0));

}

void EntradaOuSaidaDeEstoque(string op = "+")
{
    int i = 0;
    int quantidade = 0;
    bool validEntry = false;

    do
    {
        Console.WriteLine("Informe a posição da guitarra: ");
        if (int.TryParse(Console.ReadLine(), out i))
        {
            validEntry = true;
        }
        else
            validEntry = false;
    } while (!validEntry && (i > maxGuitarras || i <= 0));

    do
    {
        switch (op)
        {
            case "+":
                Console.WriteLine("Informe a quantidade de entrada: ");
                if (int.TryParse(Console.ReadLine(), out quantidade))
                {
                    validEntry = true;
                    guitarras[i - 1, 7] = (int.Parse(guitarras[i - 1, 7]) + quantidade).ToString();
                }
                else
                    validEntry = false;
                break;
            case "-":
                Console.WriteLine("Informe a quantidade de saída: ");
                if (int.TryParse(Console.ReadLine(), out quantidade))
                {
                    validEntry = true;
                    guitarras[i - 1, 7] = (int.Parse(guitarras[i - 1, 7]) - quantidade).ToString();
                }
                else
                    validEntry = false;
                break;
        }
    } while (!validEntry);

}

void ListarProdutos()
{
    int guitarraCount = QuantidadeEmEstoque();

    for (int i = 0; i < guitarraCount; i++)
    {
        Console.WriteLine($"{i + 1}. Guitarra {guitarras[i, 0]} {guitarras[i, 1]} - {guitarras[i, 4]} - {guitarras[i, 5]} - {guitarras[i, 6]} R$ {guitarras[i, 2]}) - {guitarras[i, 7]} em estoque");
    }
}

int QuantidadeEmEstoque()
{
    int guitarraCount = 0;  
    for (int i = 0; i < maxGuitarras; i++)
    {
        if (guitarras[i, 0] != "")
        {
            guitarraCount++;
        }
    }
    return guitarraCount;
}

void NovoProduto()
{
    int guitarraCount = QuantidadeEmEstoque();

    Console.WriteLine("Informe a marca: ");
    guitarras[guitarraCount, 0] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe o modelo: ");
    guitarras[guitarraCount, 1] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe o preço: ");
    guitarras[guitarraCount, 2] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe o corpo: ");
    guitarras[guitarraCount, 3] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe o captador: ");
    guitarras[guitarraCount, 4] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe o tipo de ponte: ");
    guitarras[guitarraCount, 5] = Console.ReadLine()?.ToLower() ?? "";

    Console.WriteLine("Informe a cor e acabamento: ");
    guitarras[guitarraCount, 6] = Console.ReadLine()?.ToLower() ?? "";

    guitarras[guitarraCount, 7] = "0";
}

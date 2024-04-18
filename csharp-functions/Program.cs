using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_functions
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            //// (Numeri dell esercizio)
            int[] numeri = { 2, 6, 7, 5, 3, 9 };

            //Una volta completate queste funzioni di utilità di base, e dato il seguente array di numeri [2, 6, 7, 5, 3, 9] già dichiarato nel vostro codice, si vogliono utilizzare le funzioni per:
            //- Stampare l’array di numeri fornito a video

            StampaArray(numeri);

            //- Stampare l’array di numeri fornito a video, dove ogni numero è stato prima elevato al quadrato (Verificare che l’array originale non sia stato modificato quindi ristampare nuovamente l’array originale e verificare che sia rimasto [2, 6, 7, 5, 3, 9])

            Console.WriteLine("Array che ha i numeri elevati al quadrato");
            ElevaArrayAlQuadrato(numeri);

            Console.WriteLine("Array originale");
            StampaArray(numeri);

            //- Stampare la somma di tutti i numeri

            Console.WriteLine("La somma di tutti gli elementi dell'array è: " + SommaElementiArray(numeri));

            //- Stampare la somma di tutti i numeri elevati al quadrati

            int[] copia = ElevaArrayAlQuadrato(numeri);
            Console.WriteLine("La somma di tutti gli elementi dell'array elevati a potenza è: " + SommaElementiArray(copia));

            //**BONUS:** Convertire le funzioni appena dichiarate in funzioni generiche, ossia funzioni che possono lavorare con array di numeri interi **di lunghezza variabile**, ossia debbono poter funzionare sia che gli passi array di 5 elementi, sia di 6, di 7, di ... e così via.
            //A questo punto modificare il programma in modo che chieda all’utente quanti numeri voglia inserire, e dopo di che questi vengono inseriti a mano dall’utente esternamente. Rieseguire il programma con l’input preso esternamente dall’utente.
            ////(BONUS)
            ///
            // Chiedo all'utente quanto l'array deve essere lungo (n elementi in array);
            Console.WriteLine("Inserisci la lunghezza della collezione di numeri");
            int num;

            //finche user inserisce frasi o cose che non sono interi ritorna il messaggio di errore
            while (int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("Errore, inserisci numero valido");
            }
            //creo array di lunghezza variabile

            int[] userArr = new int[num];
            int index = 0;
            // riempio l'array di numeri scelti dall'utente, con la stessa regola di controllo su cosa user inserisce.

            for (int i = 0; i < userArr.Length; i++)
            {
                Console.WriteLine($"Inserisci un numero ({i + 1}/{userArr.Length})");
                int userInt;
                while (int.TryParse(Console.ReadLine(), out userInt) == false)
                {
                    Console.WriteLine("Errore, inserisci numero valido");
                }
                userArr[index] = userInt;
                index++;
            }
            StampaArray(userArr);
            Console.WriteLine("Array che ha i numeri elevati al quadrato");
            ElevaArrayAlQuadrato(userArr);
            Console.WriteLine("Array originale");
            StampaArray(userArr);           
            Console.WriteLine("La somma di tutti gli elementi dell'array è: " + SommaElementiArray(userArr));
            int[] copiaBonus = ElevaArrayAlQuadrato(userArr);
            Console.WriteLine("La somma di tutti gli elementi dell'array elevati a potenza è: " + SommaElementiArray(copiaBonus));
        }

        //FUNZIONI
        //- **void StampaArray(int[] array)**: che preso un array di numeri interi, stampa a video il contenuto dell’array in questa forma “[elemento 1, elemento 2, elemento 3, ...]”. Potete prendere quella fatta in classe questa mattina
        static void StampaArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write($"{array[i]}");
                }
                else
                {
                    Console.Write($"{array[i]}, ");
                }
            }
            Console.WriteLine("]");
        }
        /*
        -**int Quadrato(int numero)**: che vi restituisca il quadrato del numero passato come parametro.
        */
        static int Quadrato(int numero)
        {
            return numero * numero;
        }
        /*
             - **int[] ElevaArrayAlQuadrato(int[] array)**: che preso un array di numeri interi, restituisca un nuovo array con tutti gli elementi elevati quadrato. Attenzione: è importante restituire un nuovo array, e non modificare l’array come parametro della funzione! Vi ricordate perchè? Pensateci (vedi slide)
            */
        static int[] ElevaArrayAlQuadrato(int[] array)
        {
            int[] copiaArr = (int[])array.Clone();
            int index = 0;
            foreach (int n in array)
            {
                copiaArr[index] = Quadrato(n);
                index++;
            }
            StampaArray(copiaArr);
            return copiaArr;


        }
        /*
        -**int sommaElementiArray(int[] array)**: che preso un array di numeri interi, restituisca la somma totale di tutti gli elementi dell’array.
        */
        static int SommaElementiArray(int[] array)
        {
            int sum = 0;
            foreach (int n in array)
            {
                sum += n;
            }
            return sum;
        }
    }
}

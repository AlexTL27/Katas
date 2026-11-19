    namespace rotateCorners;

    using System.Linq;

    class Program
    {
        public static object[][] RotateCorners(object[][] matrix)
        {
            int ultimaFila = matrix.Length - 1;

            int ultimaColArriba = matrix[0].Length - 1;

            int ultimaColAbajo = matrix[ultimaFila].Length - 1;
            
            //Primero saber cuanto valen las esquinas
            int n = matrix.Length;
            int totalEsquinas = ObtenerValorReal(matrix[0][0]) +
                                ObtenerValorReal(matrix[0][ultimaColArriba]) +
                                ObtenerValorReal(matrix[ultimaFila][0]) +
                                ObtenerValorReal(matrix[ultimaFila][ultimaColAbajo]);
    
            

            int totalNoEsquinas = 0;

        

            for (int a = 0; a < matrix.Length; a++)
            {
        
                for (int b = 0; b < matrix[a].Length; b++)
                {
                    // Omitir las 4 esquinas
                    if ((a == 0 && b == 0) ||                  // Esquina superior izquierda
                        (a == 0 && b == ultimaColArriba) ||          // Esquina superior derecha
                        (a == ultimaFila && b == 0) ||         // Esquina inferior izquierda
                        (a == ultimaFila && b == ultimaColAbajo))   // Esquina inferior derecha
                    {
                        continue; 
                    }

                    totalNoEsquinas += ObtenerValorReal(matrix[a][b]);
                }
            }

            matrix = Rotar(matrix, totalEsquinas * totalNoEsquinas);

            
        
        
            return new object[][] {
                new object[] {matrix[0][0] , matrix[0][ultimaColArriba]},
                new object[] {matrix[ultimaFila] [0] ,  matrix[ultimaFila][ultimaColAbajo]}
            };
        }

        public static object[][] Rotar(object[][] matrix, int rotacionturnos)
        {
            //Usar aritmética modular, para no hacer giros inecesarios
            rotacionturnos = rotacionturnos % 4;

            int ultimaFila = matrix.Length - 1;

            int ultimaColArriba = matrix[0].Length - 1;

            int ultimaColAbajo = matrix[ultimaFila].Length - 1;
                
            for(int a = 1; a < rotacionturnos; a++){
                
            
                //[X,0]
                //[0,0]
                var temp = matrix[0][0];
                
                matrix[0][0] = matrix[ultimaFila][0];


                //[0,0]
                //[X,0]
                
                matrix[ultimaFila][0] = matrix[ultimaFila][ultimaColAbajo];



                //[0,0]
                //[0,X]
                
                matrix[ultimaFila][ultimaColAbajo] = matrix[0][ultimaColArriba];


                //[0,X]
                //[0,0]
                
                matrix[0][ultimaColArriba] = temp;
            }
            return matrix;
        }

        public static int ObtenerValorReal(object valor){
            return valor switch
            {
                int numero => numero,
                char caracter => (int)caracter,
                bool booleano => booleano ? 1 : 0,
                string texto when texto.Length == 1 => (int)texto[0],
                _=>0
            };
        }
    }

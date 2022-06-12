using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador
{
    internal class Lexico
    {

        public List<Error> listaError; //SALIDA 
        public List<Token> listaToken; //atributo es la SALIDA del lexico.

        private string codigoFuente;    // atributo que representa la ENTRADA del lexico.
        private int linea;

        private int[,] matrizTransicion =
        {
             //    0       1        2       3        4       5      6       7      8      9      10     11    12      13    14      15    16     17      18     19     20     21     22    23      24     25     26       27      28       29         30      31      32
             //  let  ||  Dig   ||  +  ||   -   ||   /   ||  *  ||  =  ||   %  ||  >  ||  <  ||  ?  ||  &  ||  |  ||  ^  ||  (  ||  )  ||  .  ||  ,  ||  ;  ||  '  ||  "  ||  !  ||  {  ||  }  ||  [  ||  ]  ||  esp  ||  tab  ||  eb  ||  enter  ||  fl  ||  sl  ||  oc  ||
       /* 0 */{    1   ,    2   ,   5   ,    6   ,   7   ,   8   ,  10  ,  12   ,  13  ,  16  ,  18  ,  20  ,  22  ,  25  , -41  , -42  , -47  , -48  , -49  , -50  , -51  ,  26  , -43  , -44  , -45  , -46  ,    0   ,    0   ,   0   ,    0     ,   0   ,   0   ,  -508 },
       /* 1 */{    1   ,    1   ,  -1   ,   -1   ,  -1   ,  -1   ,  -1  ,  -1   ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  ,  -1  , -1   ,  -1  ,  -1  ,  -1  ,   -1   ,   -1   ,   -1  ,    -1    ,   -1  ,  -1   ,  -1   },
       /* 2 */{   -2   ,    2   ,  -2   ,   -2   ,  -2   ,  -2   ,  -2  ,  -2   ,  -2  ,  -2  ,  -2  ,  -2  ,  -2  ,  -2  ,  -2  ,  -2  ,  3  ,  -2  ,  -2  ,  -2  ,  -2  ,  -2  , -2   ,  -2  ,  -2  ,  -2  ,   -2   ,   -2   ,   -2  ,    -2    ,   -2  ,  -2   ,  -2   },
       /* 3 */{  -501  ,    4   , -501   ,  -501  , -501  , -501  , -501 , -501  , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 , -501 ,-501  , -501 , -501 , -501 ,  -501  ,  -501  , -501  ,    -501  ,  -501 , -501  ,  -501 },
       /* 4 */{   -3   ,    4   ,  -3   ,   -3   ,  -3   ,  -3   ,  -3  ,  -3   ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  ,  -3  , -3   ,  -3  ,  -3  ,  -3  ,   -3   ,   -3   ,  -3   ,    -3    ,   -3  ,  -3   , -3    },
       /* 5 */{  -10   ,  -10   ,  -7   ,   -10  ,  -10  , -10   , -15  ,  -10  , -10  , -10  , -10  ,  -10 , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  , -10  ,   -10  ,   -10  ,  -10  ,    -10   ,  -10  ,  -10  ,  -10  },
       /* 6 */{   -9   ,   -9   ,  -9   ,   -8   ,  -9   ,  -9   , -16  ,  -9   ,  -9  ,  -9  ,  -9  ,  -9  ,  -9  , -9   ,  -9  ,  -9  ,  -9  ,  -9  ,  -9  ,  -9  ,  -9  ,  -9  , -9   ,  -9  ,  -9  ,  -9  ,   -9   ,   -9   ,  -9   ,    -9    ,   -9  ,  -9   ,  -9   },
       /* 7 */{  -12   ,  -12   , -12   ,   -12  ,  -12  , -12   , -18  , -12   , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  , -12  ,  -12   ,   -12  ,  -12  ,    -12   ,  -12  ,  -12  ,  -12  },
       /* 8 */{  -11   ,  -11   , -11   ,   -11  ,  -11  ,   9   , -17  , -11   , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  , -11  ,  -11   ,   -11  ,  -11  ,    -11   ,  -11  ,  -11  ,  -11  },
       /* 9 */{  -13   ,  -13   , -13   ,   -13  ,  -13  , -13   , -20  , -13   , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  , -13  ,  -13   ,   -13  ,  -13  ,    -13   ,  -13  ,  -13  ,  -13  },
       /* 10 */{  -14  ,  -14   , -14   ,   -14  ,  -14  , -14   ,  11  , -14   , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  , -14  ,  -14   ,   -14  ,  -14  ,    -14   ,  -14  ,  -14  ,  -14  },
       /* 11 */{  -29  ,  -29   , -29   ,   -29  ,  -29  , -29   , -31  , -29   , -29  , -29  , -29  , -29  , -29  , -29  ,  -29 , -29  , -29  , -29  , -29  , -29  , -29  , -29  , -29  , -29  , -29  , -29  ,  -29   ,   -29  ,  -29  ,    -29   ,  -29  ,  -29  ,  -29  },
       /* 12 */{  -6   ,   -6   ,  -6   ,   -6   ,   -6  ,  -6   , -19  ,  -6   ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,  -6  ,   -6   ,   -6   ,  -6   ,   -6     ,  -6   ,  -6   ,  -6   },
       /* 13 */{  -33  ,  -33   , -33   ,   -33  ,  -33  , -33   , -34  , -33   ,  14  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  , -33  ,  -33   ,   -33  ,  -33  ,    -33   ,  -33  ,  -33  ,  -33  },
       /* 14 */{ -502  , -502   ,-502   ,  -502  , -502  , -502  , -21  , -502  ,  15  , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 , -502 ,  -502  ,   -502 ,  -502 ,    -502  ,  -502 , -502  ,  -502 },
       /* 15 */{ -503  , -503   ,-503   ,  -503  , -503  , -503  , -23  , -503  , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 , -503 ,  -503  ,   -503 ,  -503 ,    -503  ,  -503 , -503  ,  -503 },
       /* 16 */{  -35  ,  -35   , -35   ,   -35  ,  -35  ,  -35  , -36  , -35   , -35  ,  17  , -35  , -35  , -35  , -35  , -35  , -35  , -35  , -35  , -35  , -35  , -35  ,  -35 , -35  , -35  , -35  , -35  ,  -35   ,   -35  ,  -35  ,    -35   ,  -35  ,  -35  ,  -35  },
       /* 17 */{ -504  , -504   ,-504   ,  -504  , -504  , -504  , -22  , -504  , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 , -504 ,  -504  ,   -504 ,  -504 ,    -504  ,  -504 , -504  ,  -504 },
       /* 18 */{  -40  ,  -40   , -40   ,   -40  ,  -40  ,  -40  , -40  ,  -40  , -40  , -40  ,  19  , -40  , -40  , -40  , -40  , -40  , -40  , -40  , -40  , -40  , -40  ,  -40 , -40  , -40  , -40  , -40  ,  -40   ,   -40  ,  -40  ,    -40   ,  -40  ,  -40  ,  -40  },
       /* 19 */{ -505  , -505   ,-505   ,  -505  , -505  , -505  , -28  , -505  , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 , -505 ,  -505  ,   -505 ,  -505 ,    -505  ,  -505 , -505  ,  -505 },
       /* 20 */{  -37  ,  -37   , -37   ,   -37  ,  -37  , -37   , -37  ,  -37  , -37  , -37  , -37  ,  21  , -37  , -37  , -37  , -37  , -37  , -37  , -37  , -37  , -37  ,  -37 , -37  , -37  , -37  , -37  ,  -37   ,   -37  ,  -37  ,    -37   ,  -37  ,  -37  ,  -37  },
       /* 21 */{ -506  , -506   ,-506   ,  -506  , -506  , -506  , -26  , -506  , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 , -506 ,  -506  ,   -506 ,  -506 ,    -506  ,  -506 , -506  ,  -506 },
       /* 22 */{ -507  , -507   ,-507   ,  -507  , -507  , -507  , -25  , -507  , -507 , -507 , -507 , -507 ,  23  , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 , -507 ,  -507  ,   -507 ,  -507 ,    -507  ,  -507 , -507  ,  -507 },
       /* 23 */{  -38  ,  -38   , -38   ,   -38  ,  -38  , -38   , -27  ,  -38  , -38  , -38  , -38  , -38  , -38  , -38  , -38  , -38  , -38  , -38  ,  -38 , -38  , -38  ,  -38 , -38  , -38  , -38  , -38  ,  -38   ,   -38  ,  -38  ,    -38   ,  -38  ,  -38  ,  -38  },
       /* 24 */{ -508  , -508   ,-508   ,  -508  , -508  , -508  , -24  , -508  , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 , -508 ,  -508  ,   -508 ,  -508 ,    -508  ,  -508 , -508  ,  -508 },
       /* 25 */{  -39  ,  -39   , -39   ,   -39  ,  -39  ,  -39  ,  26  ,  -39  , -39  , -39  , -39  , -39  , -39  , -39  , -39  , -39  , -39  , -39  ,  -39 , -39  , -39  ,  -39 , -39  , -39  , -39  , -39  ,  -39   ,   -39  ,  -39  ,    -39   ,  -39  ,  -39  ,  -39  },
       /* 26 */{  -30  ,  -30   , -30   ,   -30  ,  -30  ,  -30  , -32  ,  -30  , -30  , -30  , -30  , -30  , -30  , -30  , -30  , -30  , -30  , -30  ,  -30 , -30  , -30  ,  -30 , -30  , -30  , -30  , -30  ,  -30   ,   -30  ,  -30  ,    -30   ,  -30  ,  -30  ,  -30  },
       
        };

        /// <summary>
        /// Cosntructor 
        /// </summary>
        /// <param name="codigo">el contenido del archivo que abrimos</param>
        public Lexico(string codigoFuenteInterface)
        {
            codigoFuente = codigoFuenteInterface + " ";
            listaToken = new List<Token>();  // inicializar
            listaError = new List<Error>();  // inicializar
        } //constructor


        /// <summary>
        /// metodo para regresar el token de la palabra reservada
        /// </summary>
        /// <param name="lexema">cadena que compone el token</param>
        /// <returns></returns>
        private int esPalabraReservada(string lexema)
        {
            switch (lexema)
            {
                case "break":
                    return -52;
                case "case":
                    return -53;
                case "catch":
                    return -54;
                case "class":
                    return -55;
                case "const":
                    return -56;
                case "continue":
                    return -57;
                case "debugger":
                    return -58;
                case "default":
                    return -59;
                case "delete":
                    return -60;
                case "do":
                    return -61;
                case "else":
                    return -62;
                case "export":
                    return -63;
                case "extends":
                    return -64;
                case "finally":
                    return -65;
                case "for":
                    return -66;
                case "function":
                    return -67;
                case "if":
                    return -68;
                case "import":
                    return -69;
                case "in":
                    return -70;
                case "instanceof":
                    return -71;
                case "new":
                    return -72;
                case "return":
                    return -73;
                case "super":
                    return -74;
                case "switch":
                    return -75;
                case "this":
                    return -76;
                case "throw":
                    return -77;
                case "try":
                    return -78;
                case "typeof":
                    return -79;
                case "var":
                    return -80;
                case "void":
                    return -81;
                case "while":
                    return -82;
                case "with":
                    return -83;
                case "yield":
                    return -84;
                case "implements":
                    return -85;
                case "interface":
                    return -86;
                case "public":
                    return -87;
                case "private":
                    return -88;
                case "protected":
                    return -89;
                case "static":
                    return -90;
                case "abstract":
                    return -91;
                case "boolean":
                    return -92;
                case "byte":
                    return -93;
                case "char":
                    return -94;
                case "double":
                    return -95;
                case "final":
                    return -96;
                case "float":
                    return -97;
                case "goto":
                    return -98;
                case "int":
                    return -99;
                case "long":
                    return -100;
                case "native":
                    return -101;
                case "short":
                    return -102;
                case "synchronized":
                    return -103;
                case "throws":
                    return -104;
                case "transient":
                    return -105;
                case "volatile":
                    return -106;
                case "number":
                    return -107;
                case "bigInt":
                    return -108;
                case "null":
                    return -109;
                case "true":
                    return -110;
                case "false":
                    return -111;
                case "arguments":
                    return -112;
                case "get":
                    return -113;
                case "set":
                    return -114;
                default:
                    return -1;
            }
        }

        /// <summary>
        /// es el metodo que me regrese el siguiente caracter del codigo fuente
        /// </summary>
        /// <returns></returns>
        private char SiguienteCaracter(int i)
        {
            return Convert.ToChar(codigoFuente.Substring(i, 1));
        }

        private int RegresarColumna(char caracter)
        {
            if (char.IsLetter(caracter))
            {
                return 0;
            }
            else if (char.IsDigit(caracter))
            {
                return 1;
            }
            else if (caracter.Equals('.'))
            {
                return 2;
            }
            else if (caracter.Equals(';'))
            {
                return 3;
            }
            else if (caracter.Equals('+'))
            {
                return 4;
            }
            else if (caracter.Equals('-'))
            {
                return 5;
            }
            else if (caracter.Equals('*'))
            {
                return 6;
            }
            else if (caracter.Equals('/'))
            {
                return 7;
            }
            else if (caracter.Equals('='))
            {
                return 8;
            }
            else if (caracter.Equals('>'))
            {
                return 9;
            }
            else if (caracter.Equals('<'))
            {
                return 10;
            }
            else if (caracter.Equals('{'))
            {
                return 11;
            }
            else if (caracter.Equals('}'))
            {
                return 12;
            }
            else if (caracter.Equals('('))
            {
                return 13;
            }

            else if (caracter.Equals(')'))
            {
                return 14;
            }
            else if (caracter.Equals('['))
            {
                return 15;
            }

            else if (caracter.Equals(']'))
            {
                return 16;
            }
            else if (caracter.Equals(':'))
            {
                return 17;
            }

            else if (caracter.Equals(','))
            {
                return 18;
            }
            else if (caracter.Equals('"'))
            {
                return 19;
            }

            else if (caracter.Equals("'"))
            {
                return 20;
            }
            else if (caracter.Equals('|'))
            {
                return 21;
            }

            else if (caracter.Equals('&'))
            {
                return 22;
            }
            else if (caracter.Equals('*'))
            {
                return 23;
            }

            else if (caracter.Equals('_'))
            {
                return 24;
            }
            else if (caracter.Equals('!'))
            {
                return 25;
            }

            else if (caracter.Equals(' '))
            {
                return 26;
            }
            else if (caracter.Equals('\n'))//enter
            {
                return 27;
            }

            else if (caracter.Equals('\t')) //tab
            {
                return 28;
            }

            else  //simbolo desconocido
            {
                return 30;
            }


        }
        
   

        private TipoToken esTipo(int estado)
        {
            switch (estado)
            {
                case -1:
                    return TipoToken.Identificador;
                case -2:
                    return TipoToken.Numeroentero;
                case -3:
                    return TipoToken.Numerodecimal;
                case -4:
                    return TipoToken.Cadena;
                case -5:
                    return TipoToken.Caracter;
                case -6:
                    return TipoToken.OperadorAritmetico;
                case -7:
                    return TipoToken.OperadorAritmetico;
                case -8:
                    return TipoToken.OperadorAritmetico;
                case -9:
                    return TipoToken.OperadorAritmetico;
                case -10:
                    return TipoToken.OperadorAritmetico;
                case -11:
                    return TipoToken.OperadorAritmetico;
                case -12:
                    return TipoToken.OperadorAritmetico;
                case -13:
                    return TipoToken.OperadorAritmetico;
                case -14:
                    return TipoToken.OperadorAsignacion;
                case -15:
                    return TipoToken.OperadorAsignacion;
                case -16:
                    return TipoToken.OperadorAsignacion;
                case -17:
                    return TipoToken.OperadorAsignacion;
                case -18:
                    return TipoToken.OperadorAsignacion;
                case -19:
                    return TipoToken.OperadorAsignacion;
                case -20:
                    return TipoToken.OperadorAsignacion;
                case -21:
                    return TipoToken.OperadorAsignacion;
                case -22:
                    return TipoToken.OperadorAsignacion;
                case -23:
                    return TipoToken.OperadorAsignacion;
                case -24:
                    return TipoToken.OperadorAsignacion;
                case -25:
                    return TipoToken.OperadorAsignacion;
                case -26:
                    return TipoToken.OperadorAsignacion;
                case -27:
                    return TipoToken.OperadorAsignacion;
                case -28:
                    return TipoToken.OperadorComparacion;
                case -29:
                    return TipoToken.OperadorComparacion;
                case -30:
                    return TipoToken.OperadorComparacion;
                case -31:
                    return TipoToken.OperadorComparacion;
                case -32:
                    return TipoToken.OperadorComparacion;
                case -33:
                    return TipoToken.OperadorComparacion;
                case -34:
                    return TipoToken.OperadorComparacion;
                case -35:
                    return TipoToken.OperadorComparacion;
                case -36:
                    return TipoToken.OperadorComparacion;
                case -37:
                    return TipoToken.OperadorLogico;
                case -38:
                    return TipoToken.OperadorLogico;
                case -39:
                    return TipoToken.OperadorLogico;
                case -40:
                    return TipoToken.OperadorCondicional;
                case -41:
                    return TipoToken.SimboloSimple;
                case -42:
                    return TipoToken.SimboloSimple;
                case -43:
                    return TipoToken.SimboloSimple;
                case -44:
                    return TipoToken.SimboloSimple;
                case -45:
                    return TipoToken.SimboloSimple;
                case -46:
                    return TipoToken.SimboloSimple;
                case -47:
                    return TipoToken.SimboloSimple;
                case -48:
                    return TipoToken.SimboloSimple;
                case -49:
                    return TipoToken.SimboloSimple;
                case -50:
                    return TipoToken.SimboloSimple;
                case -51:
                    return TipoToken.SimboloSimple;
                default:
                    return TipoToken.PalabraReservada;


            }
        }

        private Error ManejoErrores(int estado)
        {
            string mensajeError;

            switch (estado)
            {
                case -501:
                    mensajeError = "Se espera un caracter numerico";
                    break;
                case -502:
                    mensajeError = "Se espera simbolo simple";
                    break;
                case -503:
                    mensajeError = "Formato incorrecto : Se espera operador de asignacion";
                    break;
                case -504:
                    mensajeError = "Formato incorrecto : Se espera operador de asignacion";
                    break;
                case -505:
                    mensajeError = "Formato incorrecto : Se espera operador de asignacion";
                    break;
                case -506:
                    mensajeError = "Formato incorrecto : Se espera operador de asignacion";
                    break;
                case -507:
                    mensajeError = "Se espera simbolo simple";
                    break;
                case -508:
                    mensajeError = "Formato incorrecto : Se espera operador de asignacion";
                    break;
                case -509:
                    mensajeError = "Caracter desconocido";
                    break;
                default:
                    mensajeError = "Error inesperado";
                    break;
            }
            return new Error() { Codigo = estado, MensajeError = mensajeError, TipoError = tipoError.Lexico, Linea = linea };


        }



        public List<Token> EjecutarLexico()
        {
            int estado = 0; //  la fila de la matriz y el estado actual del AFD
            int columna = 0; // presenta la columna de la matriz

            char caracterActual;
            string lexema = string.Empty;
            linea = 1;

            for (int puntero = 0; puntero < codigoFuente.ToCharArray().Length; puntero++)
            {
                caracterActual = SiguienteCaracter(puntero);

                if (caracterActual.Equals('\n'))
                {
                    linea++;
                }

                lexema += caracterActual;

                columna = RegresarColumna(caracterActual);
                estado = matrizTransicion[estado, columna];

                if (estado < 0 && estado > -501) //detectar estados finales
                {
                    if (lexema.Length > 1)
                    {
                        lexema = lexema.Remove(lexema.Length - 1);
                        puntero--;
                    }


                    Token nuevoToken = new Token() { ValorToken = estado, Lexema = lexema, Linea = linea };

                    if (estado == -1)
                        nuevoToken.ValorToken = esPalabraReservada(nuevoToken.Lexema);

                    nuevoToken.TipoToken = esTipo(nuevoToken.ValorToken);

                    listaToken.Add(nuevoToken); //agrego el tokena a la lista

                    /*inicializo valores*/
                    estado = 0;
                    columna = 0;
                    lexema = string.Empty;
                }
                else if (estado <= -502)
                {
                    listaError.Add(ManejoErrores(estado));

                    estado = 0;
                    columna = 0;
                    lexema = string.Empty;
                }

                else if (estado == 0)
                {
                    columna = 0;
                    lexema = string.Empty;
                }
            }
            return listaToken; // el resultado final del lexico
        } //metodo principal de la clase lexico
    }

}

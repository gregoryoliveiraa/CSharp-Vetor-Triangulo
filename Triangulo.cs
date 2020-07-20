using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {
            int lastIndex = 1;
            int actualIndex = 1;
            int sum = 0;

            var matches = Regex.Matches(dadosTriangulo, @"\[(,?[0-9]+)*\]");

            foreach (Match item in matches)
            {
                var numbers = Regex.Matches(item.Value, @"[0-9][0-9]?");
                int actual = 0;

                foreach (Match n in numbers)
                {
                    if (lastIndex == n.Index || lastIndex + 2 == n.Index)
                    {
                        var number = int.Parse(n.Value);
                        if (actual < number)
                        {
                            actual = number;
                            actualIndex = n.Index;
                        }
                    }
                }
                sum += actual;
                lastIndex = actualIndex;
            }
            return sum;
        }
    }
}

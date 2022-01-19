#include <cstddef> // std::size_t
#include <iostream>
#include "cuadrado.hpp"
#include "triangulo.hpp"

void mostrar_figuras(Cuadrado*  c_begin,
                     Cuadrado*  c_end,
                     Triangulo* t_begin,
                     Triangulo* t_end) {
  while (c_begin != c_end) {
    std::cout << "Figura:    " << c_begin->get_nombre()    << std::endl;
    std::cout << "Perímetro: " << c_begin->get_perimetro() << std::endl;
    std::cout << "Area:      " << c_begin->area()          << std::endl;
    ++c_begin;
  }
  while (t_begin != t_end) {
    std::cout << "Figura:    " << t_begin->get_nombre()    << std::endl;
    std::cout << "Perímetro: " << t_begin->get_perimetro() << std::endl;
    std::cout << "Area:      " << t_begin->area()          << std::endl;
    ++t_begin;
  }
}

int main() {
  constexpr std::size_t num_cuadrados {2};
  constexpr std::size_t num_triangulos {2};

  Cuadrado cuadrados[num_cuadrados] {
    std::move(Cuadrado{"Cuadrado 2", 2}),
    std::move(Cuadrado{"Cuadrado 3", 3})
  };

  Triangulo triangulos[num_triangulos] {
    std::move(Triangulo{"Triangulo 234", 2,3,4}),
    std::move(Triangulo{"Triangulo 456", 4,5,6})
  };

  mostrar_figuras(cuadrados, cuadrados + num_cuadrados,
                  triangulos, triangulos + num_triangulos);
}

#include <iostream>
#include <cmath>
double* mathEquation (double a, double b, double c) {
    double D = pow(b, 2) - (4 * a * c);
    if (D < 0) return 0;
    double roots [2] = { 0, 0 };
    roots[0] = (-b + sqrt(D)) / (2 * a);
    roots[1] = (-b - sqrt(D)) / (2 * a);
    return roots;
}

char coutDivisionIntoMultipliers (double a, double x1, double x2) {
    std::cout << a << "(x - " << "(" << x1 << "))(x - " << "(" << x2 << "))";
    return ' ';
}

int main () {
    double a = 1, b = 1, c = 1, count = 1;
    std::cout << "I will solve any quadratic equation, just...";
    do {
        std::cout << "\nEnter variables A, B, C (enter 0 for close)" << std::endl;
        std::cin >> a >> b >> c;
        if (a == 0 && b == 0 && c == 0) break;
        double* equationRoots = mathEquation(a, b, c);
        if (equationRoots != 0) {
            double x1 = equationRoots[0], x2 = equationRoots[1];
            std::cout << count << ") " << "Roots of quadratic equation: " << x1 << " and " << x2 << std::endl << "   ";
            std::cout << coutDivisionIntoMultipliers(a, x1, x2) << "- equation divided by multipliers" << std::endl;
        } else { std::cout << "   " << count << ") Has not roots" << std::endl; }
        count++;
    } while (true);
    
    return 0;
}
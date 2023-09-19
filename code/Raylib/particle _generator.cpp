#include "raylib.h"
#include <cmath>

#define MAX_PARTICLES 1000 // maximum number of particles

struct Particle {
    Vector2 position;
    Vector2 velocity;
    Color color;
    float radius;
};

Particle particles[MAX_PARTICLES];

int main() {
    const int screenWidth = 800;
    const int screenHeight = 450;
    InitWindow(screenWidth, screenHeight, "Particle Simulation");

    for (int i = 0; i < MAX_PARTICLES; i++) {
        particles[i].position = { GetRandomValue(0, screenWidth), GetRandomValue(0, screenHeight) };
        particles[i].velocity = { GetRandomValue(-100, 100), GetRandomValue(-100, 100) };
        particles[i].color = { GetRandomValue(0, 255), GetRandomValue(0, 255), GetRandomValue(0, 255), 255 };
        particles[i].radius = GetRandomValue(1, 10);
    }

    SetTargetFPS(60);
    while (!WindowShouldClose()) {
        BeginDrawing();
        ClearBackground(BLACK);

        for (int i = 0; i < MAX_PARTICLES; i++) {
            particles[i].position.x += particles[i].velocity.x * GetFrameTime();
            particles[i].position.y += particles[i].velocity.y * GetFrameTime();

            // Bounce off the screen edges
            if (particles[i].position.x < 0 || particles[i].position.x > screenWidth) {
                particles[i].velocity.x *= -1;
            }
            if (particles[i].position.y < 0 || particles[i].position.y > screenHeight) {
                particles[i].velocity.y *= -1;
            }

            // Draw the particle
            DrawCircleV(particles[i].position, particles[i].radius, particles[i].color);
        }

        EndDrawing();
    }

    CloseWindow();
    return 0;
}

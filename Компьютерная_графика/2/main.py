import pygame
import os

WHITE = (255, 255, 255)
BLACK = (0, 0, 0)
# BLACK = (255, 255, 255)
# WHITE = (0, 0, 0)

#расположение окна
j = 500
i = 100

# os.environ['SDL_VIDEO_WINDOW_POS'] = "%d,%d" % (x, y)
# --------------------------------------------------------------------
print("Лабораторная работа №2. Выполнила Зиновьева Полина, 6303-020302D")
print("Введите масштаб: ")
k = float(input())
if k != 0:
    pygame.init()

W = 400
H = 400

sc = pygame.display.set_mode((W, H))
pygame.display.set_caption("Множества Жулиа")
sc.fill(BLACK)


FPS = 30  # число кадров в секунду
clock = pygame.time.Clock()

c = complex(-0.39054, -0.58679)

P = 200                     # размер [2*P+1 x 2*P+1]
scale = P / k               # масштабный коэффициент
n_iter = 100                # число итераций для проверки принадлежности к множеству Жулиа


for j in range(-P, P):
    for i in range(-P, P):
        a = i / scale
        b = j / scale
        z = complex(a, b)
        n = 0
        for n in range(n_iter):
            z = pow(z, 2) + c
            if abs(z) > 2:
                break
        if n == n_iter - 1:
            r = g = b = 0
        else:
            r = (n % 2) * 64 + 20
            g = (n % 4) * 45 + 2
            b = (n % 2) * 10 + 100
            # r = (n % 2) * 32 + 128
            # g = (n % 4) * 64
            # b = (n % 2) * 16 + 128
            pygame.draw.circle(sc, (r, g, b), (j + P, i + P), 1)

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            exit()

    pygame.display.update()
    clock.tick(FPS)
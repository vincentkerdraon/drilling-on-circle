# Circle + drilling graphical resources

## Dimensions

Circle-point.png is 100x100 px (centered)

Circle-background.jpg is 980x980 (centered)\
Diameter of circle = 2*375 = 750px\
Coordinates in image from bottom left ; direction top right
- Center = {490;490}
-   0 degres (top)    = {490;490+375} = {490;865}
-  90 degres (right)  = {490+375;490} = {865;490}
- 180 degres (bottom) = {490;490-375} = {490;115}
- 270 degres (left)   = {490-375;490} = {115;490}
- alpha degres        = {490-375;490} = {115;490}
```
alphaTrigo=-(alpha-90)
{
    x = 490 + 750/ 2 * Cos(alphaTrigo * PI / 180)
    y = 490 + 750/ 2 * Sin(alphaTrigo * PI / 180)
}
```

## Algorithm of placement

1) Find size of container. image is square, find smaller dimension.
2) Scale image to fit container ((Wimage=Wcontainer && Himage=Wcontainer) || (Himage=Hcontainer && Wimage=Hcontainer)) 
3) Position image in middle of container with offset: {+ (Wcontainer-Wimage)/2;+ (Hcontainer-Himage)/2}
4) Position drillings, for example for angle alpha:
```
angleTrigo=-(alpha-90)
{position in image}={center}+{diameter/2 * Cos(angleTrigo * PI / 180) ; diameter/2 * Sin(angleTrigo * PI / 180)}
{x;y}={offset container}+scale*{position in image}
```

## Example

Angle=0 (top)\
Container size: {500;1000}
```
|                   |
|                   |
|*******************|
|*        #        *|
|*                 *|
|*        +        *|
|*                 *|
|*                 *|
|*                 *|
|*******************|
|                   |
```
=> image is scaled to {500;500}, ratio = 500/980 = 0.51\
=> image position in container {0;250} _(distance from bottom left)_ \
=> center of circle relative to container: {0 + 0.51 * 490 ; 250 + 0.51 * 490}={249.9;499.9}\
=> drilling angle=0 relative to image (calculated by calculation lib): {position in image}={490;865}\
=> drilling angle=0 relative to image: {0;250} + 0.51 * {490;865} = {249.9;691.15}

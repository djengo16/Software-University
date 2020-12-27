class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(p1, p2) {
        var xDiff = p1.x - p2.x;
        var yDiff = p1.y - p2.y;

        return Math.sqrt(xDiff * xDiff + yDiff * yDiff);
    }
}

let p1 = new Point(5, 0);
let p2 = new Point(10, 0);

console.log(Point.distance(p1, p2));

function add(a) {

    sum = 0;

    function inner(b) {
        sum += b;
        return inner;
    }
    inner.toString = () =>{
        return sum;
    }

    return inner(a);

}
console.log(add(1)(6)(-3).toString());

function run(n){
    return n*2;
}
console.log(run(3))
let arr = ["apple", 1, 2,3, run(3),{"a":"1", 'b':"we", "1":"g"}];
console.log(arr);

const fruits = ["Apple", "Banana", "Mango", "Orange", "Grapes"];

for (let i = 0; i < fruits.length; i++) {
    console.log(fruits[i]);
}
fruits.push("papaya");
console.log(fruits)
fruits.pop();
console.log(fruits)
fruits.unshift("Kiwi");
console.log(fruits)
fruits.shift()
console.log(fruits)
console.log(fruits.includes("Mango"));
console.log(fruits.indexOf("Banana"));

let nums= [1,2,3,4,50]
console.log(nums.map((n)=>{return n*2}));

console.log(nums.filter((n)=>{return n>20}));
console.log(nums.reduce((acc, curr) =>{return acc + curr}, 0));

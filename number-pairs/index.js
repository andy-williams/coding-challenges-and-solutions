// O(n) time
// O(n) space
// can optimise further by doing single pass instead of two
// and using for loop rather than array.prototype.forEach
const findPairs = (values, target) => {
  var hashTable = {};
  values.forEach((v) => {
    hashTable[v] = hashTable[v] 
      ? hashTable[v] + 1 
    	: 1;
  });
  
  
  let pairs = Object.keys(hashTable).map((key) => {
    key = parseInt(key);
    const pairToFind = target - key;
    
    if(pairToFind == key && hashTable[pairToFind] > 1)
       return [key, key];
    
    if(hashTable[pairToFind])
      return [key, pairToFind];
    
    return null;
  }).filter(x => x != null);
  
  return pairs[0] ? pairs[0] : [];
}

console.log(findPairs([14, 7, 7, 4, 6, 2], 13)) // should be 7, 6
console.log(findPairs([14, 7, 7, 4, 6, 2], 14)) // should be 7, 7
console.log(findPairs([14, 7, 7, 4, 6, 2], -5))
console.log(findPairs([14, 7, 7, 4, 6, 2], 8))
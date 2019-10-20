// [0 ... i, i ... j, j ... last ]

// cases:
// [1, 0, 1, 0, 1]				 	-> [1], [0, 1], [0, 1] 		-> [0, 3]
//  0  1  2  3  4
//  Math.floor(4 - 0 / 3) = 1
// 0, 2, 5
// 
// [0, 0, 1, 0, 1, 0, 1] 		-> [0,0,1], [0,1], [0,1]	-> [2, 5]
// [1, 1, 0, 1, 1, 1, 1]

// invalid cases:
// [1, 1, 0, 1, 1, 1, 1, 0]				-> [1], [0,0,0,1], [1]		-> [0, 4]


const partitionBinaryArray = (binaryArray) => {
  let ones = [];
  let zeroes = [];
  
  for(let i = 0; i < binaryArray.length; i++) {
    if(binaryArray[i] == 1) ones.push(i);
    if(binaryArray[i] == 0) zeroes.push(i);
  }
  
  if(ones.length == 0)
    return [0, 1];
  
  if(ones.length % 3 > 0)
    return null;
  
  const maxOnes = Math.round(ones.length / 3);
  
  let onesFound = 0;
  let partitionValue = null;
  let currentPartition = [];
  let partitionIndices = [];
  
  for(let i = 0; i < binaryArray.length; i++) {
    currentPartition.push(binaryArray[i]);
    
    if(binaryArray[i] == 1) {
      onesFound++;
    }
    
    if((partitionIndices.length == 2 && i == binaryArray.length - 1) 
       || (partitionIndices.length < 2 && onesFound != 0 && onesFound % maxOnes == 0)) {
      const thisPartitionValue = binValue(currentPartition);
      if(partitionValue !== null && thisPartitionValue !== partitionValue) {
        return null;
      } else {
        partitionValue = thisPartitionValue
      }
      
      partitionIndices.push(i);
      currentPartition = [];
      onesFound = 0;
    }
  }
  
  return [partitionIndices[0], partitionIndices[1]];
}

function binValue(ones) {
  return parseInt(ones.join(''));
}

console.log(partitionBinaryArray([1, 1, 1]));
console.log(partitionBinaryArray([0, 0, 0]));
console.log(partitionBinaryArray([1, 0, 1, 0, 1]));
console.log(partitionBinaryArray([0, 0, 1, 0, 1, 0, 1]));
console.log(partitionBinaryArray([0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1]));

console.log(partitionBinaryArray([1, 1, 0, 1, 1, 1, 1, 0])); // invalid
# Performance Analysis

## Before optimization

| surface size x num drops | debug time(ms) | release time (ms) |
|--------------------------|----------------|-------------------|
| 100 x 100                | 154            | 123               |
| 500 x 500                | 2298           | 2266              |
| 3000 x 3000              | 6887           | 6488              |
| 4000 x 4000              | 5485           | 4587              |

## After Optimizations

| surface size x num drops | debug time(ms) | release time (ms) |
|--------------------------|----------------|-------------------|
| 100 x 100                | 75             | 43                |
| 500 x 500                | 1094           | 696               |
| 3000 x 3000              | 3053           | 1133              |
| 4000 x 4000              | 3753           | 1264              |

## Results

By optimizing the calls to math.pow I was able to
significantly reduce the debug and release times.
on average debug times went down by 47.73605% 
and release times went down by 72.36675%
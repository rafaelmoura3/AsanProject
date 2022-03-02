export default {
  shipHealthSvg (life) {
    if (life == 100) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"
                    ></path>
                <path id="path1"
                
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path6"
                
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
    if (life >= 75 && life < 100) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"
                    
                    ></path>
                <path id="path1"
                
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path6"
                
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
    if (life >= 50 && life < 75) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"
                    
                    ></path>
                <path id="path1"
                
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path6"
                
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
    if (life >= 25 && life < 50) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"
                    
                    ></path>
                <path id="path1"
                
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path6"
                
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="green" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
    if (life > 0 && life < 25) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"
                    
                    ></path>
                <path id="path1"
                
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="orange" fill-rule="evenodd"></path>
                <path id="path6"
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
    if (life == 0) {
      return `<svg id="svg" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="400"
            height="125.69941444372154" viewBox="0, 0, 400,125.69941444372154">
            <g id="svgg">
                <path id="path0"
                    d="M4.500 62.417 L 4.500 123.500 50.000 123.500 L 95.500 123.500 95.500 62.417 L 95.500 1.333 50.000 1.333 L 4.500 1.333 4.500 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"
                    
                    ></path>
                <path id="path1"
                    d="M311.000 62.417 L 311.000 123.500 354.667 123.500 L 398.333 123.500 398.333 62.417 L 398.333 1.333 354.667 1.333 L 311.000 1.333 311.000 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
                <path id="path2"
                 
                    d="M4.416 62.417 L 4.417 123.583 50.000 123.584 L 95.583 123.584 50.042 123.542 L 4.500 123.499 4.458 62.375 L 4.416 1.250 4.416 62.417 M105.500 62.417 L 105.500 123.500 152.250 123.500 L 199.000 123.500 199.000 62.417 L 199.000 1.333 152.250 1.333 L 105.500 1.333 105.500 62.417 M398.375 62.375 L 398.333 123.499 354.625 123.542 L 310.917 123.584 354.630 123.625 C 389.478 123.658,398.360 123.624,398.423 123.458 C 398.466 123.344,398.483 95.800,398.459 62.250 L 398.416 1.250 398.375 62.375 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
                <path id="path3"
                style="opacity: 0"
                    d="M0.000 62.833 L 0.000 125.667 200.000 125.667 L 400.000 125.667 400.000 62.833 L 400.000 0.000 200.000 0.000 L 0.000 0.000 0.000 62.833 M95.500 62.500 L 95.500 123.667 49.958 123.625 L 4.417 123.583 4.375 62.458 L 4.333 1.333 49.916 1.333 L 95.500 1.333 95.500 62.500 M199.125 62.458 L 199.083 123.583 152.250 123.583 L 105.417 123.583 105.375 62.458 L 105.333 1.333 152.250 1.333 L 199.167 1.333 199.125 62.458 M301.167 62.500 L 301.167 123.667 254.292 123.625 L 207.417 123.583 207.375 62.458 L 207.333 1.333 254.250 1.333 L 301.167 1.333 301.167 62.500 M398.459 62.458 L 398.417 123.583 354.708 123.625 L 311.000 123.667 311.000 62.500 L 311.000 1.333 354.750 1.333 L 398.500 1.333 398.459 62.458 "
                    stroke="none" fill="white" fill-rule="evenodd"></path>
                <path id="path4"
                    d="M207.500 62.417 L 207.500 123.500 254.250 123.500 L 301.000 123.500 301.000 62.417 L 301.000 1.333 254.250 1.333 L 207.500 1.333 207.500 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
                <path id="path5"
               
                    d="M105.416 62.417 L 105.417 123.583 152.250 123.583 L 199.083 123.583 199.084 62.417 L 199.084 1.250 199.042 62.375 L 199.000 123.500 152.250 123.500 L 105.500 123.500 105.458 62.375 L 105.416 1.250 105.416 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
                <path id="path6"
                    d="M207.416 62.417 L 207.417 123.583 254.292 123.625 L 301.167 123.667 301.125 62.459 L 301.084 1.250 301.042 62.375 L 301.000 123.500 254.250 123.500 L 207.500 123.500 207.458 62.375 L 207.416 1.250 207.416 62.417 "
                    stroke="none" fill="red" fill-rule="evenodd"></path>
            </g>
        </svg>`
    }
  }
}
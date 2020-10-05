import cv2
import sys
import time

if __name__ == "__main__":
    if len(sys.argv) < 3:
        print(__doc__)
        sys.exit(1)
    
    cv2.setUseOptimized(True)
    cv2.setNumThreads(4)

    image = cv2.imread(sys.argv[1])

    new_height = 400
    new_width = int(image.shape[1]*new_height/image.shape[0])
    image = cv2.resize(image,(new_width, new_height))

    ss = cv2.ximgproc.segmentation.createSelectiveSearchSegmentation()
    ss.setBaseImage(image)

    start_time = time.time()
    if(sys.argv[2] == 'f'):
        ss.switchToSelectiveSearchFast()
        print("Model Fast")
    elif(sys.argv[2] == 'q'):
        ss.switchToSelectiveSearchQuality()
        print("model Quality")
    else: 
        print(__doc__)
        sys.exit(1)

    rects = ss.process()
    print("Total number of region proposal: "+str(len(rects)))
    number_show_region = 100
    increment = 50

    while True:
        image_out = image.copy()

        for i, rect in enumerate(rects):
            if (i < number_show_region):
                x, y, w, h = rect
                # print(rect)
                cv2.rectangle(image_out, (x, y), (x+w, y+h), (0, 255, 0), 1, cv2.LINE_AA)
            else:
                break

        end_time = time.time()
        cv2.imshow("output",image_out)
        print("Time process: " + str(end_time - start_time))
        k = cv2.waitKey(0) & 0xFF

        if k == 109: # press l
            number_show_region += increment
        elif k == 108: # press m
            number_show_region -= increment
        elif k == 113:
            break
    cv2.destroyAllWindows()
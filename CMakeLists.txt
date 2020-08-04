cmake_minimum_required(VERSION 3.0.0)
project(training_opencv VERSION 0.1.0)

include(CTest)
enable_testing()

add_executable(training_opencv 
    src/main.cpp
)

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)

cmake_minimum_required(VERSION 3.12)
project(pemsa_pinvoke)

set(CMAKE_POSITION_INDEPENDENT_CODE ON)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -fPIC")

add_subdirectory(libs/pemsa)

include_directories(include/ libs/pemsa/include/ libs/pemsa/libs/lua/ libs/pemsa/libs/fixmath/ include/)
add_library(pemsa_pinvoke SHARED src/pemsa_pinvoke.cpp src/pinvoke_graphics_backend.cpp src/pinvoke_input_backend.cpp src/pinvoke_audio_backend.cpp)

target_link_libraries(pemsa_pinvoke pemsa)
set_target_properties(pemsa_pinvoke PROPERTIES LIBRARY_OUTPUT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/dist/)
set_target_properties(pemsa_pinvoke PROPERTIES RUNTIME_OUTPUT_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/dist/)
# CMakeList.txt: OpenGL_Learning 的 CMake 项目，在此处包括源代码并定义
# 项目特定的逻辑。
#
cmake_minimum_required (VERSION 3.20)
project ("OpenGL_Learning")

# 头文件搜索路径添加，这样就不需要相对项目路径寻址了
include_directories(${PROJECT_SOURCE_DIR}/includes)

SET(SRC_LIST  "includes/OpenGL_Learning.h"  "includes/Shader_s.h" "includes/stb_image.h" "includes/stb_image.cpp" 
        "includes/camera.h" "includes/mesh.h" "includes/model.h")
SET(MAIN_FILE    "Code/advanced_opengl/blending_sorted.cpp")

find_package(glfw3 CONFIG REQUIRED)
find_package(glad CONFIG REQUIRED)
find_package(glm CONFIG REQUIRED)
find_package(assimp CONFIG REQUIRED)


# 将指定添加到头文件搜索路径下
add_executable (OpenGL_Learning ${SRC_LIST} ${MAIN_FILE} )



target_link_libraries(OpenGL_Learning PRIVATE glfw)
target_link_libraries(OpenGL_Learning PRIVATE glad::glad)
target_link_libraries(OpenGL_Learning PRIVATE glm::glm)
target_link_libraries(OpenGL_Learning PRIVATE assimp::assimp)
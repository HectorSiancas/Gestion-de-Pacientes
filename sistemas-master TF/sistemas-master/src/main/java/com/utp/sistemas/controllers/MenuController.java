package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.Menu;
import com.utp.sistemas.services.MenuService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/menus")
public class MenuController {

    @Autowired
    private MenuService menuService;

    @PostMapping
    public Menu createMenu(@RequestBody Menu menu) {
        return menuService.createMenu(menu);
    }

    @GetMapping
    public List<Menu> getAllMenus() {
        return menuService.getAllMenus();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Menu> getMenuById(@PathVariable Integer id) {
        return menuService.getMenuById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<Menu> updateMenu(@PathVariable Integer id, @RequestBody Menu menuDetails) {
        Menu updatedMenu = menuService.updateMenu(id, menuDetails);
        return updatedMenu != null ? ResponseEntity.ok(updatedMenu) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteMenu(@PathVariable Integer id) {
        menuService.deleteMenu(id);
        return ResponseEntity.noContent().build();
    }
}
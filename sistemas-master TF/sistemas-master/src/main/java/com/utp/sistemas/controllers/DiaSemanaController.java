package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.DiaSemana;
import com.utp.sistemas.services.DiaSemanaService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/dias-semana")
public class DiaSemanaController {

    @Autowired
    private DiaSemanaService diaSemanaService;

    @PostMapping
    public DiaSemana createDiaSemana(@RequestBody DiaSemana diaSemana) {
        return diaSemanaService.createDiaSemana(diaSemana);
    }

    @GetMapping
    public List<DiaSemana> getAllDiasSemana() {
        return diaSemanaService.getAllDiasSemana();
    }

    @GetMapping("/{id}")
    public ResponseEntity<DiaSemana> getDiaSemanaById(@PathVariable Integer id) {
        return diaSemanaService.getDiaSemanaById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<DiaSemana> updateDiaSemana(@PathVariable Integer id, @RequestBody DiaSemana diaSemanaDetails) {
        DiaSemana updatedDiaSemana = diaSemanaService.updateDiaSemana(id, diaSemanaDetails);
        return updatedDiaSemana != null ? ResponseEntity.ok(updatedDiaSemana) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteDiaSemana(@PathVariable Integer id) {
        diaSemanaService.deleteDiaSemana(id);
        return ResponseEntity.noContent().build();
    }
}